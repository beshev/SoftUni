using Git.Data.Models;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(string name, string repositoryType,string userId);

        IEnumerable<RepoViewModel> GetAll();

        IEnumerable<RepoViewModel> GetPrivate(string userId);

        Repository GetRepo(string id);
    }
}
