namespace ProductShop
{
    using ProductShop.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {

            //Do not forget to add $
            return "Successfully imported {Products.Count}";
        }
    }
}