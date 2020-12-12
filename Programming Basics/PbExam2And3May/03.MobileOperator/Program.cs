using System;

namespace _03.MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contract = Console.ReadLine();
            string typeContract = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double totalSum = 0;

            switch (contract)
            {
                case "one":
                    switch (typeContract)
                    {
                        case "Small":
                            totalSum = 9.98;
                            break;
                        case "Middle":
                            totalSum = 18.99;
                            break;
                        case "Large":
                            totalSum = 25.98;
                            break;
                        case "ExtraLarge":
                            totalSum = 35.99;
                            break;
                    }
                    break;
                case "two":
                    switch (typeContract)
                    {
                        case "Small":
                            totalSum = 8.58;
                            break;
                        case "Middle":
                            totalSum = 17.09;
                            break;
                        case "Large":
                            totalSum = 23.59;
                            break;
                        case "ExtraLarge":
                            totalSum = 31.79;
                            break;
                    }
                    break;
            }
            switch (internet)
            {
                case "yes":
                    if (totalSum <= 10)
                    {
                        totalSum += 5.50;
                    }
                    else if (totalSum <= 30)
                    {
                        totalSum += 4.35;
                    }
                    else
                    {
                        totalSum += 3.85;
                    }
                    break;
            }

            if (contract == "two")
            {
                totalSum -= totalSum * 0.0375;
            }
            totalSum *= months;
            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
