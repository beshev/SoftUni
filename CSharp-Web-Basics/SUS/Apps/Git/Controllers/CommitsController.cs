using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create(string id)
        {
            var repo = this.repositoriesService.GetRepo(id);

            return this.View(repo);
        }

        [HttpPost]
        public HttpResponse Create(string name,string id)
        {
            return this.View();
        }
    }
}
