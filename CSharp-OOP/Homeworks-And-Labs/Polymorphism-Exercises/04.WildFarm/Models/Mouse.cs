using _04.WildFarm.Common;
using System;
namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        private const double INCREASING_WEIGHT = 0.10;

        public Mouse(string name, double weight,string livingRegion) : base(name, weight,livingRegion)
        {
        }

        public override void ProduceSound(Food food)
        {
            Console.WriteLine("Squeak");
            if ((food is Vegetable || food is Fruit) == false)
            {
                Console.WriteLine(GlobalConst.FOOD_NOT_EATH_MSG, this.GetType().Name, food.GetType().Name);
                return;
            }
            this.FoodEaten += food.Quantity;
            this.Weigth += (INCREASING_WEIGHT * food.Quantity);
        }
    }
}