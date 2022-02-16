using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Services.CardService;
using SMS.Services.Users;
using SMS.ViewModel.Products;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartsService cartsService;

        public CartsController(
            Request request,
            ICartsService cartsService)
            : base(request)
        {
            this.cartsService = cartsService;
        }

        [Authorize]
        public Response Details()
        {
            var viewModel = this.cartsService.CartProducts(this.User.Id);

            return this.View(new { IsAuthenticated = true, Products = viewModel });
        }

        [Authorize]
        public Response Buy()
        {
            this.cartsService.Buy(this.User.Id);

            return this.Redirect("/");
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            this.cartsService.AddProductToCart(this.User.Id, productId);

            return this.Redirect("Details");
        }
    }
}
