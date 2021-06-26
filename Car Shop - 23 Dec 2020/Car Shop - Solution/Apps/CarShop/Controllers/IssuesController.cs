namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Issues;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;

        public IssuesController(IIssuesService issuesService)
        {
            this.issuesService = issuesService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateIssueInputModel input)
        {
     
            return this.Redirect("/Cars/All");
        }
    }
}
