namespace BattleCards.Services
{
    using BattleCards.Data;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    using BattleCards.Models;
    using System.Linq;

    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Create(AddCardInputModel card)
        {
            var dbCard = new Card
            {
                Name = card.Name,
                ImageUrl = card.ImageUrl,
                Keyword = card.Keyword,
                Attack = card.Attack,
                Health = card.Health,
                Description = card.Description
            };

            this.db.Cards.Add(dbCard);
            this.db.SaveChanges();
            return dbCard.Id;
        }

        public IEnumerable<CardsViewModel> GetAll()
        {
            var cards = this.db.Cards.Select(x => new CardsViewModel
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description
            }).ToList();

            return cards;
        }

        public IEnumerable<CardsViewModel> GetMyCollection(string id)
        {
            var myCards = this.db.UserCards.Where(x => x.UserId == id)
               .Select(x => new CardsViewModel
               {
                   Attack = x.Card.Attack,
                   Description = x.Card.Description,
                   Health = x.Card.Health,
                   ImageUrl = x.Card.ImageUrl,
                   Name = x.Card.Name,
                   Keyword = x.Card.Keyword,
                   Id = x.CardId,
               }).ToList();

            return myCards;
        }

        public void AddToMyCollection(int cardId, string userId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId
            });

            this.db.SaveChanges();
        }

        public void RemoveToMyCollection(int cardId, string userId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
