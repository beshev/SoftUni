﻿namespace _06.FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        public int Food { get; }

        public string Name { get; set; }

        public void BuyFood();
    }
}
