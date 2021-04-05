using System;

namespace _03.CruiseShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string typeCabin = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double sum = 0;

            switch (type)
            {
                case "Mediterranean":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            sum = 27.50;
                            break;
                        case "cabin with balcony":
                            sum = 30.20;
                            break;
                        case "apartment":
                           sum =  40.50;
                            break;
                    }
                    break;
                case "Adriatic":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            sum = 22.99;
                            break;
                        case "cabin with balcony":
                            sum = 25;
                            break;
                        case "apartment":
                            sum = 34.99;
                            break;
                    }
                    break;
                case "Aegean":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            sum = 23;
                            break;
                        case "cabin with balcony":
                            sum = 26.60;
                            break;
                        case "apartment":
                            sum = 39.80;
                            break;
                    }
                    break;
            }
            sum *= 4;
            sum *= nights;
            if (nights  > 7)
            {
                sum -= sum * 0.25;
            }
            Console.WriteLine($"Annie's holiday in the {type} sea costs {sum:F2} lv.");
        }
    }
}
