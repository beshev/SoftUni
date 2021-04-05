using System;

namespace _18.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForHall = double.Parse(Console.ReadLine());
            double priceCake = priceForHall * 0.20;
            double priceDrinks = priceCake - (priceCake * 0.45);
            double priceAnimatор = priceForHall * 1 / 3;

            double sum = priceCake + priceDrinks + priceAnimatор + priceForHall;
            Console.WriteLine(sum);

        }
    }
}
