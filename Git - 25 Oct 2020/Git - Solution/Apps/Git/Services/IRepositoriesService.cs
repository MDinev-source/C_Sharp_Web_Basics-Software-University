namespace Git.Services
{
    using Git.Data.Models;
    using Git.ViewModels.Repositories;
    using System.Collections.Generic;

    public interface IRepositoriesService
    {
        IEnumerable<AllRepositoriesViewModel> GetAll(string userId);
        void Create(CreateRepositoryViewModel input);
        Repository GetRepoById(string repoId);
    }
}
