namespace CarDealer
{
    using CarDealer.DTO.ExportDTO;
    using CarDealer.DTO.ImportDTO;
    using CarDealer.Models;

    using Data;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            ResetDatabase(context);

            #region Imports
            string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersXml));
            Console.WriteLine(ImportParts(context, partsXml));
            Console.WriteLine(ImportCars(context, carsXml));
            Console.WriteLine(ImportCustomers(context, customersXml));
            Console.WriteLine(ImportSales(context, salesXml));
            #endregion

            Console.WriteLine(GetCarsWithDistance(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
            Console.WriteLine(GetCarsFromMakeBmw(context));
            Console.WriteLine(GetLocalSuppliers(context));
            Console.WriteLine(GetCarsWithTheirListOfParts(context));
            Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        #region Import Methods
        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Suppliers", typeof(ImportSupplierDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDTO[] supplierDtos = (ImportSupplierDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImporter)
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Parts", typeof(ImportPartDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartDTO[] partDtos = (ImportPartDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                Part part = new Part()
                {
                    Name = partDto.Name,
                    Price = decimal.Parse(partDto.Price),
                    Quantity = int.Parse(partDto.Quantity),
                    SupplierId = int.Parse(partDto.SupplierId)
                };

                parts.Add(part);
            }

            parts = parts
                .Where(p => context.Suppliers.Any(x => x.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Cars", typeof(ImportCarDTO[]));
            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDTO[] carDtos = (ImportCarDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();
                foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    };

                    currentCarParts.Add(partCar);
                }

                car.PartCars = currentCarParts;

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Customers", typeof(ImportCustomerDTO[]));
            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomerDTO[] customerDtos = (ImportCustomerDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();
            foreach (var customerDto in customerDtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = DateTime.Parse(customerDto.BirthDate),
                    IsYoungDriver = bool.Parse(customerDto.IsYoungDriver)
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Sales", typeof(ImportSaleDTO[]));
            using StringReader stringReader = new StringReader(inputXml);

            ImportSaleDTO[] saleDtos = (ImportSaleDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                Sale sale = new Sale()
                {
                    CarId = int.Parse(saleDto.CarId),
                    CustomerId = int.Parse(saleDto.CustomerId),
                    Discount = decimal.Parse(saleDto.Discount)
                };

                sales.Add(sale);
            }

            sales = sales
                .Where(p => context.Cars.Any(x => x.Id == p.CarId))
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        #endregion

        #region Export Methods
        //14. Export Cars With Distance 
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarsWithDistanceDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportCarsWithDistanceDTO[] carsDtos = context
                .Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, carsDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        //15. Export Cars From Make BMW 
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarsBMWDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportCarsBMWDTO[] dtos = context
                .Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarsBMWDTO
                {
                    Id = x.Id.ToString(),
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return stringWriter.ToString().Trim();
        }

        //16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("suppliers", typeof(ExportLocalSuppliersDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportLocalSuppliersDTO[] dtos = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSuppliersDTO()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    PartsCount = x.Parts.Count().ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        //17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarAndPartsDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportCarAndPartsDTO[] dtos = context
                .Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x=>x.Model)
                .Select(x => new ExportCarAndPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString(),
                    Parts = x.PartCars
                    .OrderByDescending(x => x.Part.Price)
                    .Select(k => new ExportPartFromCarsDTO()
                    {
                        Name = k.Part.Name,
                        Price = k.Part.Price.ToString()
                    }).ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        //18. Export Total Sales By Customer 
        //TODO: Вдигам ръце.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("customers", typeof(ExportSalesByCutomerDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportSalesByCutomerDTO[] customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(c => new ExportSalesByCutomerDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count.ToString("f2"),
                    SpentMoney = c.Sales.Select(x => x.Car)
                                        .SelectMany(y => y.PartCars)
                                        .Sum(z => z.Part.Price)
                                        .ToString("f2")
                })
                .OrderByDescending(m => m.SpentMoney)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, customers, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        //19. Export Sales With Applied Discount 
        //TODO: Вече просто си нямам и на идея къде бъркам.....
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            XmlSerializer xmlSerializer = GenerateXmlSerializer("sales", typeof(ExportSalesWithDiscountDTO[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportSalesWithDiscountDTO[] dtos = context
                .Sales
                .Select(s => new ExportSalesWithDiscountDTO()
                {
                    Car = new ExportSalesCarDTO()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount.ToString("f2"),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                                         s.Car.PartCars.Sum(pc => pc.Part.Price) *
                                         s.Discount / 100).ToString("f2")
                })
                .ToArray();

            xmlSerializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Private Methods
        //Generating Xml Serializer method
        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);

            return xmlSerializer;
        }

        //Reset database
        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Database reset sucess!");
        }
        #endregion
    }
}