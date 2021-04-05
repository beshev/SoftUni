using System;

namespace _06.BakingCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBakers = int.Parse(Console.ReadLine());
            int counterTotalProducts = 0;
            double totalSum = 0;
            for (int i = 0; i < numBakers; i++)
            {
                int counterCookies = 0;
                int counterCakes = 0;
                int counterWaffles = 0;
                string nameBaker = Console.ReadLine();
                string bakerProduct = Console.ReadLine();
                while (bakerProduct != "Stop baking!")
                {
                    int numProduct = int.Parse(Console.ReadLine());
                    counterTotalProducts += numProduct;
                    switch (bakerProduct)
                    {
                        case "cookies":
                            totalSum += numProduct * 1.50;
                            counterCookies += numProduct;
                            break;
                        case "cakes":
                            totalSum += numProduct * 7.80;
                            counterCakes += numProduct;
                            break;
                        case "waffles":
                            totalSum += numProduct * 2.30;
                            counterWaffles += numProduct;
                            break;
                    }
                    bakerProduct = Console.ReadLine();
                }
                Console.WriteLine($"{nameBaker} baked {counterCookies} cookies, {counterCakes} cakes and {counterWaffles} waffles.");
            }
            Console.WriteLine($"All bakery sold: {counterTotalProducts}");
            Console.WriteLine($"Total sum for charity: {totalSum:f2} lv.");
        }
    }
}
