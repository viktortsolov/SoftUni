namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;

    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(
            Request request,
            ICartService _cartService)
            : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            var products = cartService.AddProduct(productId, User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }
    }
}
