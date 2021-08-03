using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(CardInputModel model)
        {
            var card = new Card
            {
                Name = model.Name,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
                ImageUrl = model.Image,
                Keyword = model.Type,
            };

            db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAllCard()
        {
            return db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Health = x.Health,
                Attack = x.Attack,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetAllUserCards(string userId)
        {
            return db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
            {
                Id = x.Card.Id,
                Name = x.Card.Name,
                Health = x.Card.Health,
                Attack = x.Card.Attack,
                Description = x.Card.Description,
                ImageUrl = x.Card.ImageUrl,
                Type = x.Card.Keyword,
            }).ToList();
        }

        public void AddCardToUser(string userId, int cardId)
        {
            if (db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            db.UserCards.Add(new UserCard() { UserId = userId, CardId = cardId });

            db.SaveChanges();
        }

        public void RemoveCardFromUser(string userId, int cardId)
        {
            var userCard = db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            db.UserCards.Remove(userCard);

            db.SaveChanges();
        }
    }
}
