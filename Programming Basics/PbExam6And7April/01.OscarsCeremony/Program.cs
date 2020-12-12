using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceHall = int.Parse(Console.ReadLine());

            double priceFigurines = priceHall - priceHall * 0.3;
            double priceCatering = priceFigurines - priceFigurines * 0.15;
            double priceSounds = priceCatering - (double)1 / 2 * priceCatering;
            double totalSum = priceCatering + priceFigurines + priceHall + priceSounds;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
