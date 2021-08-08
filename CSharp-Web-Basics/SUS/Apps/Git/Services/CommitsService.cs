using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string userId, string repoId, string description)
        {
            var commit = new Commit
            {
                Description = description,
                RepositoryId = repoId,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
            };

            db.Commits.Add(commit);
            db.SaveChanges();
        }

        public void Delete(string commitId,string userId)
        {
            var commit = db.Commits.FirstOrDefault(x => x.Id == commitId && x.CreatorId == userId);

            db.Commits.Remove(commit);
            db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            return db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    CommitId = x.Id,
                    CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy HH:mm"),
                    Description = x.Description,
                    RepoName = x.Repository.Name,
                })
                .ToArray();
        }
    }
}
