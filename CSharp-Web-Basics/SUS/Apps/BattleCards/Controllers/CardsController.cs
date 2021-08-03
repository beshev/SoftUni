using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardInputModel model)
        {
            if (model.Name.Length < 5 || model.Name.Length > 15)
            {
                return this.Error("The name should be between 5 and 15 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                return this.Error("ImageUrl is required.");
            }

            if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return this.Error("ImageUrl should be valid.");
            }

            if (string.IsNullOrWhiteSpace(model.Type))
            {
                return this.Error("Keyword is required.");
            }

            if (model.Attack <= 0)
            {
                return this.Error("The attack cannot be zero or negative number.");
            }

            if (model.Health <= 0)
            {
                return this.Error("The health cannot be zero or negative number.");
            }

            if (model.Description.Length > 200)
            {
                return this.Error("The description cannot be null, and the size must be between 1 and 200.");
            }

            var cardId = this.cardsService.AddCard(model);
            var userId = this.GetUserId();
            this.cardsService.AddCardToUser(userId,cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewMode = this.cardsService.GetAllCard();

            return this.View(viewMode);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }


            var viewMode = this.cardsService.GetAllUserCards(this.GetUserId());

            return this.View(viewMode);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }


            this.cardsService.AddCardToUser(this.GetUserId(), cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.cardsService.RemoveCardFromUser(this.GetUserId(), cardId);
            return this.Redirect("/Cards/Collection");
        }
    }
}
