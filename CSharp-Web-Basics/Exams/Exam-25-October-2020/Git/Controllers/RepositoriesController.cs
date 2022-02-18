using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Services.Repositories;
using Git.Services.Validators;
using Git.ViewModels.Repositories;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly IValidatorsService validatorsService;

        public RepositoriesController(
            Request request,
            IRepositoriesService repositoriesService,
            IValidatorsService validatorsService)
            : base(request)
        {
            this.repositoriesService = repositoriesService;
            this.validatorsService = validatorsService;
        }

        public Response All()
        {
            var viewModel = this.repositoriesService.GetAllPublic();

            return this.View(new
            {
                this.User.IsAuthenticated,
                Repos = viewModel,
            });
        }

        [Authorize]
        public Response Create()
        {
            return this.View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Create(RepositoryInputModel model)
        {
            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect("/Repositories/Create");
            }

            this.repositoriesService.Create(model, this.User.Id);

            return this.Redirect("/Repositories/All");
        }
    }
}
