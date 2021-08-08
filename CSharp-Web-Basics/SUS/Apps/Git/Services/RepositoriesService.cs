using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string repositoryType, string userId)
        {
            var repo = new Repository
            {
                Name = name,
                IsPublic = repositoryType == "Public",
                CreatedOn = DateTime.Now,
                OwnerId = userId,

            };

            db.Repositories.Add(repo);
            db.SaveChanges();
        }

        public IEnumerable<RepoViewModel> GetAll()
        {
            return this.db.Repositories
                .Where(x => x.IsPublic)
                .Select(x => new RepoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy HH:mm"),
                    CommitsCount = x.Commits.Count()
                })
                .ToList();
        }

        public IEnumerable<RepoViewModel> GetPrivate(string userId)
        {
            return this.db.Repositories
                   .Where(x => !x.IsPublic && x.OwnerId == userId)
                   .Select(x => new RepoViewModel
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Owner = x.Owner.Username,
                       CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy HH:mm"),
                       CommitsCount = x.Commits.Count()
                   })
                   .ToList();
        }

        public Repository GetRepo(string id)
        {
            return this.db.Repositories.FirstOrDefault(x => x.Id == id);
        }
    }
}
