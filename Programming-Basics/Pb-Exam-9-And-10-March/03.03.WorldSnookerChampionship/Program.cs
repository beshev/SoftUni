using System;

namespace _03._03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticket = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());
            char picture = char.Parse(Console.ReadLine());
            double sum = 0;


            switch (stage)
            {
                case "Quarter final":
                    switch (ticket)
                    {
                        case "Standard":
                            sum = 55.50;
                            break;
                        case "Premium":
                            sum = 105.20;
                            break;
                        case "VIP":
                            sum = 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticket)
                    {
                        case "Standard":
                            sum = 75.88;
                            break;
                        case "Premium":
                            sum = 125.22;
                            break;
                        case "VIP":
                            sum = 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (ticket)
                    {
                        case "Standard":
                            sum = 110.10;
                            break;
                        case "Premium":
                            sum = 160.66;
                            break;
                        case "VIP":
                            sum = 400;
                            break;
                    }
                    break;
            }
            sum *= numTickets;
            double totalSum = sum;
            if (sum > 4000)
            {                
                sum -= sum * 0.25;
            }
            else if (sum > 2500)
            {
                sum -= sum * 0.10;
            }
            if (picture == 'Y' && totalSum <= 4000)
            {
                numTickets *= 40;
                sum += numTickets;
            }
            Console.WriteLine($"{sum:F2}");


        }

    }
}
