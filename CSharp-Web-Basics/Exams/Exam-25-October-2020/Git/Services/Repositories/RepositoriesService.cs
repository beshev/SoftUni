using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;

namespace Git.Services.Repositories
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly IRepository repo;

        public RepositoriesService(IRepository repo)
        {
            this.repo = repo;
        }
        public void Create(RepositoryInputModel model, string userId)
        {
            var repo = new Data.Models.Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == "Public",
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            this.repo.Add(repo);
            this.repo.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAllPublic()
            => this.repo
            .All<Data.Models.Repository>()
            .Where(x => x.IsPublic)
            .Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn.ToString("d"),
                CommitsCount = x.Commits.Count(),
            })
            .AsEnumerable();

        public RepositoryCommitInputModel GetRepo(string id)
            => this.repo
            .All<Data.Models.Repository>()
            .Select(x => new RepositoryCommitInputModel
            {
                Name = x.Name,
                Id = x.Id
            })
            .FirstOrDefault(x => x.Id == id);
    }
}
