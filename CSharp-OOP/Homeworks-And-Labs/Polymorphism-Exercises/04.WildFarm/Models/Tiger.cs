using System;

using _04.WildFarm.Common;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        private const double INCREASING_WEIGHT = 1.00;

        public Tiger(string name, double weight, string livingRegion,string breed) : base(name, weight, livingRegion,breed)
        { }

        public override void ProduceSound(Food food)
        {
            Console.WriteLine("ROAR!!!");
            if ((food is Meat) == false)
            {
                Console.WriteLine(GlobalConst.FOOD_NOT_EATH_MSG, this.GetType().Name, food.GetType().Name);
                return;
            }
            this.FoodEaten += food.Quantity;
            this.Weigth += (INCREASING_WEIGHT * food.Quantity);
        }
    }
}