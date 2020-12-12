using System;

namespace _01.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numChichens = int.Parse(Console.ReadLine());
            int numFish = int.Parse(Console.ReadLine());
            int numVegetable = int.Parse(Console.ReadLine());

            double priceChichen = numChichens * 10.35;
            double priceFish = numFish * 12.40;
            double priceVegetable = numVegetable * 8.15;
            double totalSum = priceChichen + priceFish + priceVegetable;
            totalSum += (totalSum * 0.2);
            totalSum += 2.50;
            Console.WriteLine($"Total: {totalSum:F2}");
        }
    }
}
