using System;

namespace _03._1EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            int totalPrice = 0;

            switch (destination)
            {
                case "France":
                    switch (date)
                    {
                        case "21-23":
                            totalPrice = nights * 30;
                            break;
                        case "24-27":
                            totalPrice = nights * 35;
                            break;
                        case "28-31":
                            totalPrice = nights * 40;
                            break;
                    }
                    break;
                case "Italy":
                    switch (date)
                    {
                        case "21-23":
                            totalPrice = nights * 28;
                            break;
                        case "24-27":
                            totalPrice = nights * 32;
                            break;
                        case "28-31":
                            totalPrice = nights * 39;
                            break;
                    }
                    break;
                case "Germany":
                    switch (date)
                    {
                        case "21-23":
                            totalPrice = nights * 32;
                            break;
                        case "24-27":
                            totalPrice = nights * 37;
                            break;
                        case "28-31":
                            totalPrice = nights * 43;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:f2} leva.");
        }
    }
}
