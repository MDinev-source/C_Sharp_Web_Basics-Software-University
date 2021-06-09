﻿namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using System;
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
        public void Create(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Password = ComputeHash(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public bool IsLoginValid(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameAvailable(string username)
        {
            throw new NotImplementedException();
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}