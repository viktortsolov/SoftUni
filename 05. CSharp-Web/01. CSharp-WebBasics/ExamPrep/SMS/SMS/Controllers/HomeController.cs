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
        private readonly IProductService productService;


        public HomeController(
            Request request,
            IUserService _userService,
            IProductService _productService)
            : base(request)
        {
            userService = _userService;
            productService = _productService;
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
                    Products = productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}