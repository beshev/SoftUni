using System;

namespace _02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input ->
            int numJunior = int.Parse(Console.ReadLine());
            int numSenior = int.Parse(Console.ReadLine());
            string typeRoute = Console.ReadLine();
            double price = 0;
            double juniors = numJunior * 1.0;
            double seniors = numSenior * 1.0;

            //  Find Price For Participation ->
            //  Група     trail   cross - country   downhill    road
            //  juniors    5.50         8            12.25       20
            //  seniors     7          9.50          13.75     21.50

            switch (typeRoute)
            {
                case "trail":
                    juniors *= 5.5;
                    seniors *= 7;
                    price = seniors + juniors;
                    break;
                case "cross-country":
                    juniors *= 8;
                    seniors *= 9.5;
                    price = seniors + juniors;
                    break;
                case "downhill":
                    juniors *= 12.25;
                    seniors *= 13.75;
                    price = seniors + juniors;
                    break;
                case "road":
                    juniors *= 20;
                    seniors *= 21.50;
                    price = seniors + juniors;
                    break;
            }
            // Find Discounts -> 
            if (typeRoute == "cross-country" && (numJunior + numSenior >= 50))
            {
                price -= price * 0.25;
                price -= price * 0.05;
                
            }
            else
            {
                price -= (price * 0.05);
            }

            // Print Output
            Console.WriteLine($"{price:f2}");


        }
    }
}
