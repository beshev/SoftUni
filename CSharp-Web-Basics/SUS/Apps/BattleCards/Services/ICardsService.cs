using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(CardInputModel model);

        IEnumerable<CardViewModel> GetAllCard();

        public IEnumerable<CardViewModel> GetAllUserCards(string userId);

        public void AddCardToUser(string userId, int cardId);

        public void RemoveCardFromUser(string userId, int cardId);
    }
}
