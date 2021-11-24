namespace ProductShop
{
    using AutoMapper;

    using Newtonsoft.Json;

    using ProductShop.Data;
    using ProductShop.Dtos.Input;
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