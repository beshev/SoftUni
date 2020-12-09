using System;

namespace _02.Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double gasoline = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            double totalPrice = 0;

            double priceGasoline = gasoline * 2.10;
            totalPrice += priceGasoline + 100;
            switch (day)
            {
                case "Saturday":
                    totalPrice -= (totalPrice * 0.1);
                    break;
                case "Sunday":
                    totalPrice -= totalPrice * 0.2;
                    break;
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Safari time! Money left: {budget - totalPrice:F2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {totalPrice - budget:f2} lv.");
            }

        }
    }
}
