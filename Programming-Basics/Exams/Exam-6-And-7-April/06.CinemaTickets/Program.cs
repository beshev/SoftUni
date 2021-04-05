using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int counterKid = 0;
            int counterStudent = 0;
            int counterStandard = 0;
            int totalTickets = 0;
            while (movieName != "Finish")
            {
                int freeSpace = int.Parse(Console.ReadLine());
                string typeTicket = Console.ReadLine();
                int spaceForHall = 0;
                while (typeTicket != "End")
                {
                    totalTickets++;
                    switch (typeTicket)
                    {
                        case "student":
                            counterStudent++;
                            break;
                        case "standard":
                            counterStandard++;
                            break;
                        case "kid":
                            counterKid++;
                            break;
                    }
                    spaceForHall++;
                    if (spaceForHall >= freeSpace)
                    {
                        break;
                    }
                    typeTicket = Console.ReadLine();
                }
                Console.WriteLine($"{movieName} - {spaceForHall / (double)freeSpace * 100:f2}% full.");
                movieName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{counterStudent / (double)totalTickets * 100:F2}% student tickets.");
            Console.WriteLine($"{counterStandard / (double)totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{counterKid / (double)totalTickets * 100:f2}% kids tickets.");
        }
    }
}
