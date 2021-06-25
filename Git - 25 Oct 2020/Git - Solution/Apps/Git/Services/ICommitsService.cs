namespace Git.Services
{
    using Git.ViewModels.Commits;
    using System.Collections.Generic;

    public interface ICommitsService
    {
        void Create(string repoId, string description, string userId);

        IEnumerable<AllCommitsViewModel> GetALL(string userId);

        void Delete(string id, string userId);
    }
}
