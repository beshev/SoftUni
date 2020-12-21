using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int orders = int.Parse(Console.ReadLine());
            double sum = 0;

            switch (size)
            {
                case "small":
                    switch (fruit)
                    {
                        case "Watermelon":
                            sum = 56 * 2;
                            break;
                        case "Mango":
                            sum = 36.66 * 2;
                            break;
                        case "Pineapple":
                            sum = 42.10 * 2;
                            break;
                        case "Raspberry":
                            sum = 20 * 2;
                            break;
                    }
                    break;
                case "big":
                    switch (fruit)
                    {
                        case "Watermelon":
                            sum = 28.70 * 5;
                            break;
                        case "Mango":
                            sum = 19.60 * 5;
                            break;
                        case "Pineapple":
                            sum = 24.80 * 5;
                            break;
                        case "Raspberry":
                            sum = 15.20;
                            break;
                    }
                    break;
            }
            sum *= orders;

            if (sum >= 400 && sum <= 1000)
            {
                sum -= sum * 0.15;
            }
            else if (sum > 1000)
            {
                sum -= sum * 0.5;
            }           
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
