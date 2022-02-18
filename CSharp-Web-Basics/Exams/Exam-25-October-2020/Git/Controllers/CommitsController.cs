using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Services.Commits;
using Git.Services.Repositories;
using Git.Services.Validators;
using Git.ViewModels.Commits;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IValidatorsService validatorsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(
            Request request,
            ICommitsService commitsService,
            IRepositoriesService repositoriesService,
            IValidatorsService validatorsService)
            : base(request)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
            this.validatorsService = validatorsService;
        }

        [Authorize]
        public Response All()
        {
            var viewModel = this.commitsService.GetAll(this.User.Id);

            return this.View(new 
            { 
                IsAuthenticated = true,
                Commits = viewModel,
            });
        }

        [Authorize]
        public Response Delete(string id)
        {
            this.commitsService.Delete(id, this.User.Id);

            return this.Redirect("/Commits/All");
        }

        [Authorize]
        public Response Create(string id)
        {
            var viewModel = this.repositoriesService.GetRepo(id);

            viewModel.IsAuthenticated = true;

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public Response Create(RepositoryCommitInputModel model)
        {
            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect($"/Commits/Create?id={model.Id}");
            }

            model.CreatorId = this.User.Id;

            this.commitsService.Create(model);

            return this.Redirect("/Repositories/All");
        }
    }
}
