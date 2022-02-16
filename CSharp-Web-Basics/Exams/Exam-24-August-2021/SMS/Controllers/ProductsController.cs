using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Services.Products;
using SMS.ViewModel.Products;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(
            Request request,
            IProductsService productsService)
            : base(request)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public Response Create()
        {
            return this.View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Create(ProductInputModel model)
        {
            var validator = true;

            if (
                model.Name.Length < 4
                || model.Name.Length > 20)
            {
                validator = false;
            }

            if (
                string.IsNullOrEmpty(model.Name)
                || model.Price < 0.05m
                || model.Price > 1000m)
            {
                validator = false;
            }

            if (validator == false)
            {
                return this.Redirect("Create");
            }

            this.productsService.Add(model);

            return this.Redirect("/");
        }
    }
}
