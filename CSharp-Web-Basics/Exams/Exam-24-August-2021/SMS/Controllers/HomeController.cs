using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Services.Products;
using SMS.Services.Users;
using SMS.ViewModel.Home;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;

        public HomeController(
            Request request,
            IUsersService usersService,
            IProductsService productsService)
            : base(request)
        {
            this.usersService = usersService;
            this.productsService = productsService;
        }

        public Response Index()
        {
            var isAuthenticated = this.User.IsAuthenticated;

            if (isAuthenticated)
            {
                return IndexLoggedIn();
            }

            return this.View(new { IsAuthenticated = isAuthenticated });
        }
        
        [Authorize]
        public Response IndexLoggedIn()
        {
            var viewModel = new LoggedUserHomeViewModel
            {
                Username = this.usersService.GetUserName(this.User.Id),
                Products = this.productsService.GetAll(),
                IsAuthenticated = true,
            };

            return this.View(viewModel);
        }
    }
}