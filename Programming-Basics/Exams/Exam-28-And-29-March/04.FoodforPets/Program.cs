using System;

namespace _04.FoodforPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double allFood = double.Parse(Console.ReadLine());
            int counterDay = 0;
            double totalFoodEath = 0;
            double cooke = 0;
            double catFood = 0;
            double dogFood = 0;

            for (int i = 0; i < days; i++)
            {
                double foodForDay = 0;
                counterDay++;
                int dogEath = int.Parse(Console.ReadLine());
                int catEath = int.Parse(Console.ReadLine());
                foodForDay += dogEath;
                foodForDay += catEath;
                totalFoodEath += dogEath;
                totalFoodEath += catEath;
                catFood += catEath;
                dogFood += dogEath;
                if (counterDay == 3)
                {
                    cooke += foodForDay * 0.1;
                    counterDay = 0;
                }


            }
            Console.WriteLine($"Total eaten biscuits: {Math.Round(cooke)}gr.");
            Console.WriteLine($"{(totalFoodEath / allFood) * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(dogFood / totalFoodEath) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{(catFood / totalFoodEath) * 100:f2}% eaten from the cat.");
        }
    }
}
