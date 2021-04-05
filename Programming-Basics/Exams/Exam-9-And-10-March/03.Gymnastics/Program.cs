using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string device = Console.ReadLine();
            double endSum = 0;

            switch (country)
            {
                case "Russia":
                    switch (device)
                    {
                        case "ribbon":
                            endSum +=  9.1;
                            endSum += 9.4 ;
                            break;
                        case "hoop":
                            endSum += 9.3;
                            endSum += 9.8;
                            break;
                        case "rope":
                            endSum += 9.6;
                            endSum += 9.0;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (device)
                    {
                        case "ribbon":
                            endSum += 9.6;
                            endSum += 9.4;
                            break;
                        case "hoop":
                            endSum += 9.55;
                            endSum += 9.75;
                            break;
                        case "rope":
                            endSum += 9.5;
                            endSum += 9.4;
                            break;
                    }
                    break;
                case "Italy":
                    switch (device)
                    {
                        case "ribbon":
                            endSum += 9.2;
                            endSum += 9.5;
                            break;
                        case "hoop":
                            endSum += 9.45;
                            endSum += 9.35;
                            break;
                        case "rope":
                            endSum += 9.7;
                            endSum += 9.15;
                            break;
                    }
                    break;
            }
            double percentage = 20 - endSum;
            percentage /= 20;
            percentage *= 100;
            Console.WriteLine($"The team of {country} get {endSum:f3} on {device}.");
            Console.WriteLine($"{percentage:f2}% ");
            

        }
    }
}
