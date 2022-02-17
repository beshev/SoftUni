using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Services.Cars;
using CarShop.Services.Users;
using CarShop.Services.Validators;
using CarShop.ViewModels.Cars;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;
        private readonly IValidatorsService validatorsService;

        public CarsController(
            Request request,
            ICarsService carsService,
            IUsersService usersService,
            IValidatorsService validatorsService)
            : base(request)
        {
            this.carsService = carsService;
            this.usersService = usersService;
            this.validatorsService = validatorsService;
        }

        [Authorize]
        public Response All()
        {
            string userId = string.Empty;

            if (this.usersService.IsMechanic(this.User.Id) == false)
            {
                userId = this.User.Id;
            }

            var viewModel = this.carsService.GetAll(userId);

            return this.View(new
            {
                IsAuthenticated = true,
                Cars = viewModel,
            });
        }

        [Authorize]
        public Response Add()
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return this.Redirect("All");
            }

            return this.View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Add(CarInputModel model)
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return this.Redirect("All");
            }

            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect("Add");
            }

            this.carsService.Add(model, this.User.Id);

           return this.Redirect("All");
        }
    }
}
