namespace BattleCards.Services
{
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    public interface ICardsService
    {
        void Create(string name, string imageUrl, string keyword, int attack, int health, string description);
        IEnumerable<AllCardsViewModel> GetAll();
        bool AddCardToCollection(int cardId, string userId);
        bool RemoveCardToCollection(int cardId, string userId);
    }
}
