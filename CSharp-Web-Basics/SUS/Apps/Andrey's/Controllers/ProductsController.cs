using Andreys.Data.Models;
using Andreys.Services;
using Andreys.ViewModels.Products;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Andreys.Controllers
{
   public class ProductsController : Controller
    {
        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Add();
            }

            if (model.Description.Length > 10)
            {
                return this.Add();
            }

            if (!Uri.IsWellFormedUriString(model.ImageUrl,UriKind.Absolute))
            {
                return this.Add();
            }

            if (model.Price < 0)
            {
                return this.Add();
            }

            if (!Enum.TryParse(model.Category,true,out Category _) || !Enum.TryParse(model.Gender, true, out Gender _))
            {
                return this.Add();
            }

            this.productsService.CreateProduct(model.Name, model.Description, model.ImageUrl, model.Category, model.Gender, model.Price);

            return this.Redirect("/");

        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var productViewModel = this.productsService.GetProduct(id);

            return this.View(productViewModel);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }
    }
}
