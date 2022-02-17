using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace CarShop.Controllers
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
                return this.Redirect("/Cars/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}
