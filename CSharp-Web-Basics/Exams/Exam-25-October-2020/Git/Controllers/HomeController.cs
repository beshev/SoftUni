using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}
