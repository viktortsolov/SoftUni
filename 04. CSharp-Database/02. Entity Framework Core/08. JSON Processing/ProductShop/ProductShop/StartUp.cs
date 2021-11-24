namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos.Input;
    using ProductShop.Dtos.Output;
    using ProductShop.Models;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            string productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            string categoriesJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(ImportUsers(context, usersJsonAsString));
            Console.WriteLine(ImportProducts(context, productsJsonAsString));
            Console.WriteLine(ImportCategories(context, categoriesJsonAsString));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJsonAsString));

            Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDTO> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDTO>>(inputJson);
            InitializeMapper();

            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //02.  Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDTO> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDTO>>(inputJson);
            InitializeMapper();

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDTO> categories =
                JsonConvert.DeserializeObject<IEnumerable<CategoryInputDTO>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));

            InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductsInputDTO> categoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductsInputDTO>>(inputJson);

            InitializeMapper();

            var mappedCategoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeMapper();

            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductOutputDTO>(mapper.ConfigurationProvider)
                //.Select(x => new UserOutputDto
                //{
                //    Name = x.Name,
                //    Price = x.Price,
                //    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                //})
                .ToList();

            //var mappedResult = mapper.Map<IEnumerable<ProductOutputDTO>>(products);

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var productsASJson = JsonConvert.SerializeObject(products, jsonSettings);

            return productsASJson;
        }

        //06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeMapper();

            var usersWithSoldProdcuts = context
                .Users
                .Include(p => p.ProductsSold)
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var usersWithSoldProdcutsAsJson = JsonConvert.SerializeObject(usersWithSoldProdcuts, jsonSettings);

            return usersWithSoldProdcutsAsJson;
        }

        //07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = $"{x.CategoryProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{x.CategoryProducts.Sum(c => c.Product.Price):f2}"
                });


            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var resultAsJson = JsonConvert.SerializeObject(result, jsonSettings);

            return resultAsJson;
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderByDescending(u => u.ProductsSold.Where(ps => ps.BuyerId != null).Count())
                .Select(u => new LastNameAgeSoldDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDTO
                    {
                        Products = u.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(p => new ProductNamePriceDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                    }
                })
                .ToList();

            var usersCount = new UsersCountDTO()
            {
                UsersCount = usersWithProducts.Count,
                Users = usersWithProducts
            };

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var usersWithProductsJson = JsonConvert.SerializeObject(usersCount, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return usersWithProductsJson;
        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
    }
}