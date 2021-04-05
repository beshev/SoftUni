using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            int buyChrysan = int.Parse(Console.ReadLine());
            int buyRoses = int.Parse(Console.ReadLine());
            int buyTulip = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string restDay = Console.ReadLine();
            double chrysan = buyChrysan * 1.0;
            double roses = buyRoses* 1.0;
            double tulip = buyTulip * 1.0;
            double price = 0;

            // Price of Flowers and Add / Dicounts
            //    Сезон            Хризантеми    Рози      Лалета
            //Пролет / Лято          2.00 лв     4.10 лв.  2.50 лв.
            //Есен / Зима            3.75 лв     4.50 лв.  4.15 лв.

            switch (season)
            {
                case "Summer":
                case "Spring":
                    chrysan *= 2;
                    roses *= 4.1;
                    tulip *= 2.5;
                    price = chrysan + roses + tulip;                    
                    break;
                case"Winter":                    
                case"Autumn":
                    chrysan *= 3.75;
                    roses *= 4.5;
                    tulip *= 4.15;
                    price = chrysan + roses + tulip;
                    break;
            }
            if (restDay == "Y")
            {
                price += price * 0.15;
                if (buyTulip > 7 && season == "Spring")
                {
                    price -= (price * 0.05);
                }
                if (buyRoses >= 10  && season == "Winter")
                {
                    price -= price * 0.1;
                }
                if ( buyRoses + buyTulip + buyChrysan > 20)
                {
                    price -= price * 0.2;
                }
            }
            else
            {
                if (buyTulip > 7 && season == "Spring")
                {
                    price -= (price * 0.05);
                }
                if (buyRoses >= 10 && season == "Winter")
                {
                    price -= price * 0.1;
                }
                if (buyRoses + buyTulip + buyChrysan > 20)
                {
                    price -= price * 0.2;
                }
            }


            // Print Output
            Console.WriteLine($"{price + 2:f2}");


        }
    }
}
