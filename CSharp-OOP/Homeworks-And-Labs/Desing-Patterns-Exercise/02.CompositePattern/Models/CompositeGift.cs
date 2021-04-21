using _02.CompositePattern.Models.Contrancts;
using System.Collections.Generic;
using System;

namespace _02.CompositePattern.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> _gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{_name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

    }
}
