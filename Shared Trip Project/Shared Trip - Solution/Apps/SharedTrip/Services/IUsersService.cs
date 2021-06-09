namespace SharedTrip.Services
{
    public interface IUsersService
    {
        bool IsLoginValid(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
