using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Commits;

namespace Git.Services.Commits
{
    public class CommitsService : ICommitsService
    {
        private readonly IRepository repo;

        public CommitsService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Create(RepositoryCommitInputModel model)
        {
            var commit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                CreatorId = model.CreatorId,
                Description = model.Description,
                RepositoryId = model.Id,
            };

            this.repo.Add(commit);
            this.repo.SaveChanges();
        }

        public void Delete(string id, string userId)
        {
            var coomit = this.repo
                .All<Commit>()
                .FirstOrDefault(x => x.Id == id && x.CreatorId == userId);

            this.repo.Remove(coomit);
            this.repo.SaveChanges();
        }

        public IEnumerable<CommitViewmodel> GetAll(string userId)
            => this.repo
            .All<Commit>()
            .Where(x => x.CreatorId == userId)
            .Select(x => new CommitViewmodel
            {
                Id = x.Id,
                Description = x.Description,
                RepositoryName = x.Repository.Name,
                CreatedOn = x.CreatedOn.ToString("d"),
            })
            .AsEnumerable();
    }
}
