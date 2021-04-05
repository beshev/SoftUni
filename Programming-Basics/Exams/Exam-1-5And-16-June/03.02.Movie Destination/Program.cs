using System;

namespace _03._02.Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double priceForDay = 0;

            switch (destination)
            {
                case "Dubai":
                    switch (season)
                    {
                        case "Summer":
                            priceForDay = 40000;
                            break;
                        case "Winter":
                            priceForDay = 45000;
                            break;
                    }
                    break;
                case "Sofia":
                    switch (season)
                    {
                        case "Summer":
                            priceForDay = 12500;
                            break;
                        case "Winter":
                            priceForDay = 17000;
                            break;
                    }
                    break;
                case "London":
                    switch (season)
                    {
                        case "Summer":
                            priceForDay = 20250;
                            break;
                        case "Winter":
                            priceForDay = 24000;
                            break;
                    }
                    break;
            }
            priceForDay *= days;
            switch (destination)
            {
                case "Dubai":
                    priceForDay -= priceForDay * 0.3;
                    break;
                case "Sofia":
                    priceForDay += priceForDay * 0.25;
                    break;
            }
            if (budget >= priceForDay)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - priceForDay:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {priceForDay - budget:F2} leva more!");
            }
        }
    }
}
