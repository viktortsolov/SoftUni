using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            string suppliersJsonAsString = File.ReadAllText("../../../Datasets/suppliers.json");
            string partsJsonAsString = File.ReadAllText("../../../Datasets/parts.json");
            string carsJsonAsString = File.ReadAllText("../../../Datasets/cars.json");
            string customersJsonAsString = File.ReadAllText("../../../Datasets/customers.json");
            string salesJsonAsString = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(ImportSuppliers(context, suppliersJsonAsString));
            Console.WriteLine(ImportParts(context, partsJsonAsString));
            Console.WriteLine(ImportCars(context, carsJsonAsString));
            Console.WriteLine(ImportCustomers(context, customersJsonAsString));
            Console.WriteLine(ImportSales(context, salesJsonAsString));

            //Console.WriteLine(GetOrderedCustomers(context));
            Console.WriteLine(GetCarsFromMakeToyota(context));
        }

        #region Imports
        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierInputDTO> suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputDTO>>(inputJson);
            InitializeMapper();

            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IEnumerable<PartInputDTO> parts = JsonConvert.DeserializeObject<IEnumerable<PartInputDTO>>(inputJson);
            InitializeMapper();

            var mappedParts = mapper.Map<IEnumerable<Part>>(parts)
                .Where(p => context.Suppliers
                    .Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ICollection<CarInputDTO>>(inputJson);

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniqueParts = carDto.PartsId
                    .Distinct()
                    .ToList();

                foreach (var partId in uniqueParts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        CarId = car.Id
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<CustomerInputDTO> customers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputDTO>>(inputJson);
            InitializeMapper();

            var mappedCustomers = mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        //13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<SaleInputDTO> sales = JsonConvert.DeserializeObject<IEnumerable<SaleInputDTO>>(inputJson);
            InitializeMapper();

            var mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        #endregion

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customersDto = context.Customers
               .OrderBy(c => c.BirthDate)
               .ThenBy(c => c.IsYoungDriver)
               .ProjectTo<CustomerExportInfoDTO>(mapper.ConfigurationProvider)
               .ToList();

            var customersJson = JsonConvert.SerializeObject(customersDto, new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            });

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Model == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarExportInfoDTO>(mapper.ConfigurationProvider)
                .ToList();

            var carsJson = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return carsJson;
        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
    }
}