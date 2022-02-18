using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;

namespace Git.Services.Repositories
{
    public interface IRepositoriesService
    {
        public IEnumerable<RepositoryViewModel> GetAllPublic();

        public void Create(RepositoryInputModel model, string userId);

        public RepositoryCommitInputModel GetRepo(string id);
    }
}
