namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Issues;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateIssue(CreateIssueInputModel input)
        {
            var issue = new Issue
            {
                Description=input.Description,
                IsFixed=false,
                CarId=input.CarId
            };

            this.db.Issues.Add(issue);

            this.db.Cars.FirstOrDefault(x => x.Id == input.CarId).Issues.Add(issue);

            this.db.SaveChanges();
        }
    }
}
