using System;

namespace _02.SummerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double priceTowel = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double priceUmbrella = 2.0 / 3 * priceTowel;
            double priceFlipFlops = priceUmbrella * 0.75;
            double priceBeachBag = 1.0 / 3 * (priceTowel + priceFlipFlops);

            double totalSum = priceFlipFlops + priceTowel + priceUmbrella + priceBeachBag;
            double discountPercentage = discount / 100.0;
            totalSum -= totalSum * discountPercentage;
            if (budget >= totalSum)
            {
                Console.WriteLine($"Annie's sum is {totalSum:F2} lv. She has {budget - totalSum:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {totalSum:F2} lv. She needs {totalSum  - budget:F2} lv. more.");
            }
        }
    }
}
