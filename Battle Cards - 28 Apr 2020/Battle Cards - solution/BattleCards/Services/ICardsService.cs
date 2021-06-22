namespace BattleCards.Services
{
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    public interface ICardsService
    {
        int Create(AddCardInputModel card);
        IEnumerable<CardsViewModel> GetAll();
        IEnumerable<CardsViewModel> GetMyCollection(string id);

        void AddToMyCollection(int cardId, string userId);
        void RemoveToMyCollection(int cardId, string userId);

    }
}
