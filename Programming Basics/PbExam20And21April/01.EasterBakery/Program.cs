using System;

namespace _01.EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceFlour = double.Parse(Console.ReadLine());
            double flourKg = double.Parse(Console.ReadLine());
            double shugarKg = double.Parse(Console.ReadLine());
            int numEggBark = int.Parse(Console.ReadLine());
            int may = int.Parse(Console.ReadLine());

            double priceShugar = priceFlour - (priceFlour * 0.25);
            double priceEgg = priceFlour + (priceFlour * 0.10);
            double priceMay = priceShugar - (priceShugar * 0.8);

            priceShugar *= shugarKg;
            priceEgg *= numEggBark;
            priceMay *= may;
            priceFlour *= flourKg;

            double sum = priceEgg + priceFlour + priceMay + priceShugar;
            Console.WriteLine($"{sum:F2}");


        }
    }
}
