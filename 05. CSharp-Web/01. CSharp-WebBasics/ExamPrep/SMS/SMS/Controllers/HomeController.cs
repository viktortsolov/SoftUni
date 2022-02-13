namespace SMS.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;
    using SMS.Models.Products;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(
            Request request,
            IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                var model = new
                {
                    Username = username,
                    IsAuthenticated = true,
                    Products = new List<ProductListViewModel>()
                    {
                        new ProductListViewModel()
                        {
                            ProductName="TELEVIZIQ",
                            ProductId ="ASHDHASDH",
                            ProductPrice = "6lea bakq mi"
                        }
                    }
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}