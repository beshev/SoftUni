using System;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        private const double INCREASING_WEIGHT = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound(Food food)
        {
            Console.WriteLine("Cluck");
            this.FoodEaten += food.Quantity;
            this.Weigth += (INCREASING_WEIGHT * food.Quantity);
        }
    }
}