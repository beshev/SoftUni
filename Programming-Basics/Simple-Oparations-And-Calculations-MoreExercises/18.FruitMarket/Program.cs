using System;

namespace _18.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBerry= double.Parse(Console.ReadLine());
            double bananaKG= double.Parse(Console.ReadLine());
            double OrangeKG= double.Parse(Console.ReadLine());
            double raspberriesKG= double.Parse(Console.ReadLine());
            double berryKG= double.Parse(Console.ReadLine());

            double priceRaspberries = priceBerry / 2;
            double priceOrange =  priceRaspberries - (priceRaspberries * 0.4);
            double priceBanana = priceRaspberries -  (priceRaspberries * 0.8);
            priceBerry *= berryKG;
            priceBanana *= bananaKG;
            priceOrange *= OrangeKG;
            priceRaspberries *= raspberriesKG;

            double sum = priceRaspberries + priceOrange + priceBerry + priceBanana;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
