namespace CarShop.Services
{
    using CarShop.ViewModels.Issues;
    public interface IIssuesService
    {
        void CreateIssue(CreateIssueInputModel input);
    }
}
