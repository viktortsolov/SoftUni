namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Models.Users;

    public class UsersController : Controller
    {
        public UsersController(Request request) 
            : base(request)
        {
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false});
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            return View(new { IsAuthenticated = true });
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {

        }
    }
}
