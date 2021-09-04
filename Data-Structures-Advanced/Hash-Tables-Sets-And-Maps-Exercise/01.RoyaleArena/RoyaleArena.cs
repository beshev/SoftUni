namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> battleCards;

        public RoyaleArena()
        {
            this.battleCards = new Dictionary<int, BattleCard>();
        }

        public void Add(BattleCard card)
        {
            this.battleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.battleCards.ContainsKey(card.Id);
        }

        public int Count => this.battleCards.Count;

        public void ChangeCardType(int id, CardType type)
        {
            ValidateIfExit(id);

            this.battleCards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            ValidateIfExit(id);

            return this.battleCards[id];
        }

        public void RemoveById(int id)
        {
            ValidateIfExit(id);

            this.battleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var result = this.battleCards
                .Select(x => x.Value)
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            ValideIfEmpty(result);

            return result;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var result = this.battleCards
                  .Select(x => x.Value)
                  .Where(x => x.Type == type && x.Damage > lo && x.Damage < hi)
                  .OrderByDescending(x => x.Damage)
                  .ThenBy(x => x.Id)
                  .ToArray();

            ValideIfEmpty(result);

            return result;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var result = this.battleCards
                    .Select(x => x.Value)
                    .Where(x => x.Type == type && x.Damage <= damage)
                    .OrderByDescending(x => x.Damage)
                    .ThenBy(x => x.Id)
                    .ToArray();

            ValideIfEmpty(result);

            return result;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var result = this.battleCards
                      .Select(x => x.Value)
                      .Where(x => x.Name == name)
                      .OrderByDescending(x => x.Swag)
                      .ThenBy(x => x.Id)
                      .ToArray();

            ValideIfEmpty(result);

            return result;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var result = this.battleCards
                    .Select(x => x.Value)
                    .Where(x => x.Name == name && x.Swag >= lo && x.Swag < hi)
                    .OrderByDescending(x => x.Swag)
                    .ThenBy(x => x.Id)
                    .ToArray();

            ValideIfEmpty(result);

            return result;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.Count)
            {
                throw new InvalidOperationException();
            }

            var result = this.battleCards
                        .Select(x => x.Value)
                        .OrderBy(x => x.Swag)
                        .ThenBy(x => x.Id)
                        .Take(n)
                        .ToArray();

            return result;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return this.battleCards
                    .Select(x => x.Value)
                    .Where(x => x.Swag >= lo && x.Swag <= hi)
                    .OrderBy(x => x.Swag)
                    .ToArray();
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in this.battleCards)
            {
                yield return card.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateIfExit(int id)
        {
            if (!this.battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
        }

        private void ValideIfEmpty(BattleCard[] result)
        {
            if (result.Length == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}