using System;

namespace _03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string typeOFHall = Console.ReadLine();
            int buyTickets = int.Parse(Console.ReadLine());
            double sumTickets = 0;
            switch (movieName)
            {
                case "A Star Is Born":
                    switch (typeOFHall)
                    {
                        case "normal":
                            sumTickets = 7.50;
                            break;
                        case "luxury":
                             sumTickets = 10.50;
                            break;
                        case "ultra luxury":
                             sumTickets = 13.50;
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (typeOFHall)
                    {
                        case "normal":
                            sumTickets = 7.35;
                            break;
                        case "luxury":
                            sumTickets = 9.45;
                            break;
                        case "ultra luxury":
                            sumTickets = 12.75;
                            break;
                    }
                    break;
                case "Green Book":
                    switch (typeOFHall)
                    {
                        case "normal":
                            sumTickets = 8.15;
                            break;
                        case "luxury":
                            sumTickets = 10.25;
                            break;
                        case "ultra luxury":
                            sumTickets = 13.25;
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (typeOFHall)
                    {
                        case "normal":
                            sumTickets = 8.75;
                            break;
                        case "luxury":
                            sumTickets = 11.55;
                            break;
                        case "ultra luxury":
                            sumTickets = 13.95;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"{movieName} -> {sumTickets * buyTickets:f2} lv.");
        }
    }
}
