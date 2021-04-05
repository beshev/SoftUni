using _04.WildFarm.Common;
using System;
namespace _04.WildFarm
{
    public class Owl : Bird
    {
        private const double INCREASING_WEIGHT = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound(Food food)
        {
            Console.WriteLine("Hoot Hoot");
            if ((food is Meat) == false)
            {
                Console.WriteLine(GlobalConst.FOOD_NOT_EATH_MSG,this.GetType().Name,food.GetType().Name);
                return;
            }
            this.FoodEaten += food.Quantity;
            this.Weigth += (INCREASING_WEIGHT * food.Quantity);
        }
    }
}