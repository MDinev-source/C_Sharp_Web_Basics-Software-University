namespace BattleCards.Controllers
{
    using BattleCards.Services;
    using BattleCards.ViewModels.Cards;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class CardsCotroller : Controller
    {
        private readonly ICardsService cardsService;

        public CardsCotroller(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateCardViewModel card)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (card.Name.Length < 5 || card.Name.Length > 15)
            {
                return this.Redirect("/Cards/Add");
            }

            if (card.Health < 0 || card.Attack < 0)
            {
                return this.Redirect("/Cards/Add");
            }

            if (card.Description.Length > 200)
            {
                return this.Redirect("/Cards/Add");
            }

            this.cardsService.Create(card.Name, card.ImageUrl, card.Keyword, card.Attack, card.Health, card.Description);
            return this.Redirect("/Cards/All");

        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(this.cardsService.GetAll(), "All");
        }


        public HttpResponse AddCardToUser(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["CardId"];
            this.cardsService.AddCardToCollection(cardId, userId);

            return this.Redirect("/Cards/All");

        }


        public HttpResponse RemoveCardToUser(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["CardId"];
            var isRemoved=this.cardsService.AddCardToCollection(cardId, userId);

            if (isRemoved)
            {
                return this.Redirect("/Cards/Collection");
            }

            return this.Redirect("/Cards/All");

        }
    }
}
