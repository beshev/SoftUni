using System;

namespace _04.TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int counter = 0;
            int counterBuy = 0;
            double sum = 0;

            string name = Console.ReadLine();
            while (name != "Stop")
            {
                double price = double.Parse(Console.ReadLine());
                counter++;
                if (counter == 3)
                {
                    price /= 2.0;
                    counter = 0;
                }
                if (budget < price)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price - budget:f2} leva!");
                    return;
                }
                budget -= price;
                counterBuy++;
                sum += price;
                name = Console.ReadLine();
            }
            Console.WriteLine($"You bought {counterBuy} products for {sum:f2} leva.");
        }
    }
}
