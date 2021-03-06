namespace CarShop.Services
{
    using CarShop.ViewModels.Issues;
    public interface IIssuesService
    {
        void AddIssue(string description, string carId);

        AllIssueViewModel GetModelById(string carId);

        bool Fix(string issueId, string carId);

        bool Delete(string issueId, string carId);
    }
}
