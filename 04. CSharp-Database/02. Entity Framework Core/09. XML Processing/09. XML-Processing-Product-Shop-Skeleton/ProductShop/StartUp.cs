namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

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
            var context = new ProductShopContext();

            ResetDatabase(context);

            #region Imports
            string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            Console.WriteLine(ImportUsers(context, usersXml));
            Console.WriteLine(ImportProducts(context, productsXml));
            Console.WriteLine(ImportCategories(context, categoriesXml));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));
            #endregion

            #region Exports
            Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
            #endregion
        }

        #region Import Methods
        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Users", typeof(ImportUserDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportUserDTO[] userDtos = (ImportUserDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<User> users = new HashSet<User>();
            foreach (var userDto in userDtos)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = int.Parse(userDto.Age)
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Products", typeof(ImportProductDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportProductDTO[] productDtos = (ImportProductDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Product> products = new HashSet<Product>();
            foreach (var productDto in productDtos)
            {
                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    BuyerId = productDto.BuyerId,
                    SellerId = productDto.SellerId
                };

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Categories", typeof(ImportCategoryDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryDTO[] categoryDtos = (ImportCategoryDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                Category category = new Category()
                {
                    Name = categoryDto.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products 
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("CategoryProducts", typeof(ImportCategoryProductDTO[]));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryProductDTO[] categoryProductDtos = (ImportCategoryProductDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProductDto in categoryProductDtos)
            {
                Category category = context.Categories.FirstOrDefault(x => x.Id == categoryProductDto.CategoryId);
                Product product = context.Products.FirstOrDefault(x => x.Id == categoryProductDto.ProductId);

                if (product == null || category == null)
                    continue;

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        #endregion

        #region Export Methods
        //05. Export Products In Range
        //TODO: Remove null objects
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("products", typeof(ExportProductsInRange[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportProductsInRange[] productsDtos = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductsInRange
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, productsDtos, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        //06. Export Sold Products
        //TODO: Seems legit tbh
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("Users", typeof(ExportUsersSellersDTO[]));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportUsersSellersDTO[] usersSellersDtos = context
                .Users
                .Where(x => x.ProductsSold.Count >= 1)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new ExportUsersSellersDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(x => new ExportSoldProducts
                    {
                        Name = x.Name,
                        Price = x.Price
                    }).ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, usersSellersDtos, namespaces);

            return stringWriter.ToString().TrimEnd();
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
        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Database reset sucess!");
        }
        #endregion
    }
}