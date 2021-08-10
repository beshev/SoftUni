using CarShop.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issueService;
        private readonly IUsersService usersService;

        public IssuesController(IIssuesService issueService, IUsersService usersService)
        {
            this.issueService = issueService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.issueService.GetCarIssues(carId);

            return this.View(viewModel);
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(string carId,string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(carId) || description.Length < 5)
            {
                return this.Error("Issue description should be 5 or more characters.");
            }

            this.issueService.AddIssueToCar(carId, description);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Fix(string carId,string issueId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (!this.usersService.IsUserMechanic(this.GetUserId()))
            {
                return this.Error("You must be a mechanic to fix it.");
            }

            this.issueService.FixIssue(carId, issueId);

            return this.CarIssues(carId);
        }

        public HttpResponse Delete(string carId, string issueId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.issueService.DeleteIssue(carId,issueId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
