using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string season = Console.ReadLine();
            double kilometars = double.Parse(Console.ReadLine());
            double price = 0;

            // Find How Much Will Get For  One Season = *4;
            if (kilometars <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        price = kilometars * 0.75;
                        break;
                    case "Summer":
                        price =  kilometars * 0.90;
                        break;
                    case "Winter":
                        price = kilometars * 1.05;
                        break;
                }               
            }
            else if (kilometars <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        price = kilometars * 0.95;
                        break;
                    case "Summer":
                        price = kilometars * 1.10;
                        break;
                    case "Winter":
                        price = kilometars * 1.25;
                        break;
                }
            }
            else if (kilometars <= 20000)
            {
                price = kilometars * 1.45;
            }
            price = price * 4;
            price -= price * 0.1;
            // Print Output
            Console.WriteLine($"{price:f2}");
        }
    }
}
