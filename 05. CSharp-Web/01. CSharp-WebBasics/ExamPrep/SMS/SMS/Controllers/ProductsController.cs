namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Models.Products;

    public class ProductsController : Controller
    {
        public ProductsController(Request request) : base(request)
        {
        }

        [Authorize]
        public Response Create()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        public Response Create(CreateViewModel model)
        {

        }
    }
}
