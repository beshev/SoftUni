using System;

namespace _05.CareofPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodForDog = int.Parse(Console.ReadLine());
            foodForDog *= 1000;

            string input = Console.ReadLine();
            while (input != "Adopted")
            {
                int foodEath = int.Parse(input);
                foodForDog -= foodEath;

                input = Console.ReadLine();
            }
            if (foodForDog >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodForDog} grams.");
            }
            else if (foodForDog < 0)
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodForDog)} grams more.");
            }
        }
    }
}
