namespace Andreys.Services
{
    public interface IUsersSevice
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);
    }
}
