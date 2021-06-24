namespace SharedTrip.Services
{
    public interface IUsersService
    {
        public void RegisterUser(string username, string email, string password);
        string GetUserId(string username, string password);

        bool IsEmailAvailable(string email);
        bool IsUsernameAvailable(string username);
    }
}
