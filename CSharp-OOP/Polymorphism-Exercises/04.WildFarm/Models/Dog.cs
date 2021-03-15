using System;

using _04.WildFarm.Common;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        private const double INCREASING_WEIGHT = 0.40;

        public Dog(string name, double weight,string livingRegion) : base(name, weight,livingRegion)
        { }

        public override void ProduceSound(Food food)
        {
            Console.WriteLine("Woof!");
            if ((food is Meat) == false)
            {
                Console.WriteLine(GlobalConst.FOOD_NOT_EATH_MSG, this.GetType().Name, food.GetType().Name);
                return;
            }
            this.FoodEaten += food.Quantity;
            Weigth += (INCREASING_WEIGHT * food.Quantity);
        }
    }
}