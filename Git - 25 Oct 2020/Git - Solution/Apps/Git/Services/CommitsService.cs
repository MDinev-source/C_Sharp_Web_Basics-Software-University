using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string repoId, string description, string userId)
        {
            var commit = new Commit
            {
                RepositoryId = repoId,
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId
            };

            this.db.Commits.Add(commit);
            db.SaveChanges();
        }


        public void Delete(string id, string userId)
        {
            var submission = this.db.Commits.FirstOrDefault(x => x.Id == id);

            if (submission.CreatorId == userId)
            {
                this.db.Commits.Remove(submission);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<AllCommitsViewModel> GetALL(string userId)
        {
            var commits = this.db.Commits.Where(c => c.Repository.OwnerId == userId)
                .Select(x => new AllCommitsViewModel
                {
                    Id = x.Id,
                    RepositoryName = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString(),

                }).ToList();

            return commits;
        }
    }
}
