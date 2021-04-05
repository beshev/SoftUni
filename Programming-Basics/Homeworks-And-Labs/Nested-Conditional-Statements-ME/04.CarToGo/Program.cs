using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            double money = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            string type = "";
            string classCar = "";

            // Find Price , Type of Car And Class Car;
            if (money <= 100)
            {
                classCar = "Economy class";
                switch (season)
                {
                    case "Summer":
                        price = money * 0.35;
                        type = "Cabrio";
                        break;
                    default:
                        price = money * 0.65;
                        type = "Jeep";
                        break;
                }
              
            }
            else if (money > 100 && money <= 500)
            {
                classCar = "Compact class";
                switch (season)
                {
                    case "Summer":
                        price = money * 0.45;
                        type = "Cabrio";
                        break;
                    default:
                        price = money * 0.80;
                        type = "Jeep";
                        break;
                }

            }
            else
            {
                classCar = "Luxury class";
                price = money * 0.90;
                type = "Jeep";
            }

            // Print Output
            Console.WriteLine(classCar);
            Console.WriteLine($"{type} - {price:f2}");
        }
    }
}
