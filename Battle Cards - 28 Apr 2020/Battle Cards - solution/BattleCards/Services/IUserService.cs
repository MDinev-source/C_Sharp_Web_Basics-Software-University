namespace BattleCards.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);
        void Register(string username, string email, string password);
        bool IsUsernameExists(string username);
        bool IsEmailExists(string email);
    }
}
