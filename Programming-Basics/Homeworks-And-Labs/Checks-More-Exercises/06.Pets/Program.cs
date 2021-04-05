using System;

namespace _06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtelFood = double.Parse(Console.ReadLine());
            double dogEat = days * dogFood;
            double catEat = days * catFood;
            double turtelEat = days * turtelFood / 1000;
            double allFood = dogEat + catEat + turtelEat;
            if (food >= allFood)
            {
                Console.WriteLine($"{Math.Floor(food - allFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(allFood - food)} more kilos of food are needed.");
            }
        }
    }
}
