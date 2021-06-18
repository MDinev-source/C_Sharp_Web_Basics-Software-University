using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddCardToCollection(int cardId, string userId)
        {
            var user = this.db.Users
                .FirstOrDefault(x => x.Id == userId);

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = userId
            };

            if (!this.db.UserCards.Any(x => x.CardId == userCard.CardId && x.UserId == userCard.UserId))
            {
                user.UserCards.Add(userCard);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public void Create(string name, string imageUrl, string keyword, int attack, int health, string description)
        {
            var card = new Card
            {
                Name = name,
                ImageUrl = imageUrl,
                Keyword = keyword,
                Attack = attack,
                Health = health,
                Description = description
            };

            this.db.Cards.Add(card);
            db.SaveChanges();
        }

        public IEnumerable<AllCardsViewModel> GetAll()
        {
            return this.db.Cards
                 .Select(x => new AllCardsViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Keyword = x.Keyword,
                     Attack = x.Attack,
                     Health = x.Health,
                     Description = x.Description
                 })
                 .ToArray();
        }

        public bool RemoveCardToCollection(int cardId, string userId)
        {
            var user = this.db.Users
                .FirstOrDefault(x => x.Id == userId);

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = userId
            };

            if (this.db.UserCards.Any(x => x.CardId == userCard.CardId && x.UserId == userCard.UserId))
            {
                user.UserCards.Remove(userCard);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
