using Git.ViewModels.Commits;

namespace Git.Services.Commits
{
    public interface ICommitsService
    {
        public IEnumerable<CommitViewmodel> GetAll(string userId);

        public void Create(RepositoryCommitInputModel model);

        public void Delete(string id, string userId);
    }
}
