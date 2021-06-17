namespace BattleCards.Services
{
    using BattleCards.Data;
    using BattleCards.Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);

            var user = this.db.Users
                .FirstOrDefault(x => x.Username == username
                && x.Password == hashPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public bool IsEmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.db.Users.Add(user);

            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
