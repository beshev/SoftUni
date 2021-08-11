using Andreys.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        private IProductsService products;

        public HomeController(IProductsService products)
        {
            this.products = products;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Home();
            }

            return this.View();
        }

        public HttpResponse Home()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allProductsModel = this.products.GetAll();

            return this.View(allProductsModel);
        }
    }
}
