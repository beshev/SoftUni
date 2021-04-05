using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Цената на Ракията = Цената на уискито / 2 ;
            //Цeната на Бирата = (80 / Цената на ракията * 100);
            //Цената на Виното = (40 / Цената на Ракията * 100);

            // Бирата = Цената на Бирата * Количеството Бира
            // Виното = Цената На Виното * Количеството Вино
            // Ракията = Цената на Ракията * Количеството Ракия 
            // Уискито = Цената На Уискито * Количеството Уски

            // Общата Цената = Бирата + Виното + Ракията + Уискито 


            double priceOfWiskey = double.Parse(Console.ReadLine());
            double quantityBeer = double.Parse(Console.ReadLine());
            double quantityWine = double.Parse(Console.ReadLine());
            double quantityRakia = double.Parse(Console.ReadLine());
            double quantityWiskey = double.Parse(Console.ReadLine());

            double priceRakia = priceOfWiskey / 2;
            double priceBeer = (priceRakia - (0.8 * priceRakia));
            double priceWine = (priceRakia - (0.4 * priceRakia));

            double beer = priceBeer * quantityBeer;
            double wine = priceWine * quantityWine;
            double rakia = priceRakia * quantityRakia;
            double wiskey = priceOfWiskey * quantityWiskey;
            double sumAll = beer + wine + rakia + wiskey;

            Console.WriteLine($"{sumAll:f2}");
        }
    }
}
