using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Services.Cars;
using CarShop.Services.Issues;
using CarShop.Services.Users;
using CarShop.Services.Validators;
using CarShop.ViewModels.Issues;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IIssuesService issuesService;
        private readonly IValidatorsService validatorsService;
        private readonly IUsersService usersService;

        public IssuesController(
            Request request,
            ICarsService carsService,
            IIssuesService issuesService,
            IValidatorsService validatorsService,
            IUsersService usersService)
            : base(request)
        {
            this.carsService = carsService;
            this.issuesService = issuesService;
            this.validatorsService = validatorsService;
            this.usersService = usersService;
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            var viewModel = this.carsService.GetCarWithIssues(carId);

            viewModel.IsAuthenticated = true;

            return this.View(viewModel);
        }

        [Authorize]
        public Response Add(string carId)
        {
            return this.View(new { IsAuthenticated = true, CarId = carId });
        }

        [Authorize]
        [HttpPost]
        public Response Add(IssueInputModel model)
        {
            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect($"/Issues/Add?carId={model.CarId}");
            }

            this.issuesService.Add(model);

            return this.Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public Response Fix(string issueId, string carId)
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                this.issuesService.Fix(issueId);
            }

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public Response Delete(string issueId, string carId)
        {
            this.issuesService.Delete(issueId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
