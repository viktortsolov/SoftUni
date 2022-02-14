namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;
    using SMS.Models.Products;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(
            Request request,
            IProductService _productService)
            : base(request)
        {
            productService = _productService;
        }

        [Authorize]
        public Response Create()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Create(CreateProductViewModel model)
        {
            var (created, error) = productService.Create(model);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");
        }
    }
}
