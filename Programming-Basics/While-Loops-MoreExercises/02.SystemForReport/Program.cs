using System;

namespace _02.SystemForReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int sumForSale = int.Parse(Console.ReadLine());
            int totalSum = 0;
            double averageCash = 0;
            double averageCard = 0;
            double counterCard = 0;
            int counterCash = 0;
            int counterCardCash = 0;
            string input = Console.ReadLine();
            // Find Sum of Products
            while (input != "End")
            {
                counterCardCash++;
                 int sumProduct = int.Parse(input);
                // Pay in Cash
                if (counterCardCash == 1)
                {
                    if (sumProduct > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        totalSum += sumProduct;
                        Console.WriteLine("Product sold!");
                        averageCash += sumProduct;
                        counterCash++;
                    }
                }
                // Pay With Card
                else if (counterCardCash == 2)
                {
                    if (sumProduct < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        totalSum += sumProduct;
                        Console.WriteLine("Product sold!");
                        averageCard += sumProduct;
                        counterCard++;
                    }
                  counterCardCash = 0;
                }
                // Find if we collect sumForSale
                if (totalSum >= sumForSale)
                {
                    averageCard /= counterCard;
                    averageCash /= counterCard;
                    Console.WriteLine($"Average CS: {averageCash:f2}");
                    Console.WriteLine($"Average CC: { averageCard:f2}");
                    break;
                }                
                input = Console.ReadLine();
            }
            if (input == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
