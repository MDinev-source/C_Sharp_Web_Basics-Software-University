namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateRepositoryViewModel input)
        {
            var repositrory = new Repository
            {
                Name = input.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = input.RepositoryType == "Public" ? true : false,
                OwnerId=input.OwnerId
            };

            this.db.Repositories.Add(repositrory);
            this.db.SaveChanges();
        }

   

        public IEnumerable<AllRepositoriesViewModel> GetAll(string userId)
        {
            var respositories = this.db.Repositories.Where(r => r.IsPublic && r.OwnerId == userId)
                    .Select(x => new AllRepositoriesViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Owner = x.Owner.Username,
                        CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                        Commits = x.Commits.Count
                    }).ToList();

            return respositories;
        }

        public Repository GetRepoById(string repoId)
        {
            return this.db.Repositories.Where(r => r.Id == repoId).FirstOrDefault();
        }
    }
}
