using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string userId, string repoId, string description);

        void Delete(string commitId,string userId);

        IEnumerable<CommitViewModel> GetAll(string userId);
    }
}
