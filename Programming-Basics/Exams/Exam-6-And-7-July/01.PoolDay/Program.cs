using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeaple = int.Parse(Console.ReadLine());
            double priceForOne = double.Parse(Console.ReadLine());
            double priceForDeckChair = double.Parse(Console.ReadLine());
            double priceForUmbrella = double.Parse(Console.ReadLine());

            double totalSum = priceForOne * numPeaple;
            double totalDeck = Math.Ceiling(numPeaple * 0.75);
            double totalUmbrella = Math.Ceiling(numPeaple / (double)2);
            totalDeck *= priceForDeckChair;
            totalUmbrella *= priceForUmbrella;
            totalSum += totalUmbrella + totalDeck;
            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
