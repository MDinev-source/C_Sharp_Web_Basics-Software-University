using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService comitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService comitsService,
            IRepositoriesService repositoriesService)
        {
            this.comitsService = comitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var model = this.comitsService.GetALL(userId);

            return this.View(model);
        }

        public HttpResponse Create(string id)
        {
            var repo = this.repositoriesService.GetRepoById(id);

            var model = new CreateCommitViewModel()
            {
                Name = repo.Name,
                Id = repo.Id
            };
            return this.View(model);

        }


        [HttpPost]
        public HttpResponse Create(string id, string description)
        {


            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description is required and shoul be at least 5 cherecters");
            }

            this.comitsService.Create(id, description, this.GetUserId());

            return this.Redirect("/Repositories/All");

        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.comitsService.Delete(id, userId);

            return this.Redirect("/Commits/All");
        }

    }
}

