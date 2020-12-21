using System;

namespace _02._02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numGPU = int.Parse(Console.ReadLine());
            int numCPU = int.Parse(Console.ReadLine());
            int numRam = int.Parse(Console.ReadLine());

            double priceGPU = numGPU * 250;
            double priceCPU = priceGPU * 0.35;
            priceCPU *= numCPU;
            double priceRam = priceGPU * 0.10;
            priceRam *= numRam;
            double totalSum = priceGPU + priceCPU + priceRam;
            if (numGPU > numCPU)
            {
                totalSum -= totalSum * 0.15;
            }
            if (budget >= totalSum)
            {
                Console.WriteLine($"You have {budget - totalSum:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalSum - budget:f2} leva more!");
            }
        }
    }
}
