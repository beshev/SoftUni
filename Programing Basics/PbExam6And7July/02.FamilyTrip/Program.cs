using System;

namespace _02.FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int night = int.Parse(Console.ReadLine());
            double priceNights = double.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());
            double percentage1 = (double)percentage / 100;
            budget -= budget * percentage1;

            if (night > 7)
            {
                priceNights -= priceNights * 0.05;
            }
            priceNights *= night;

            if (budget >= priceNights)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - priceNights:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{priceNights - budget:f2} leva needed.");
            }
        }
    }
}
