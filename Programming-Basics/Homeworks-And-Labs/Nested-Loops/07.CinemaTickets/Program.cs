using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string movieName = Console.ReadLine();
            double studentsTickets = 0;
            double kidsTickets = 0;
            double standartTickets = 0;
            double totalTickets = 0;
            double hallFull = 0;

            // 1.Check We Have  Name for Movie or We "Finish" 
            //1.1And Free Space
            while (movieName != "Finish")
            {
                int freeSpace = int.Parse(Console.ReadLine());

                // Chek Free Space is empty or We have Command "End"
                string ticketsType = Console.ReadLine();
                while (ticketsType != "End")
                {
                    hallFull++;
                    totalTickets++;
                    switch (ticketsType)
                    {
                        case "student":
                            studentsTickets++;
                            break;
                        case "standard":
                            standartTickets++;
                            break;
                        case "kid":
                            kidsTickets++;
                            break;
                    }
                    if (hallFull >= freeSpace)
                    {
                        break;
                    }

                    ticketsType = Console.ReadLine();
                }
                // free space hall in Percentage:
                Console.WriteLine($"{movieName} - {(hallFull / freeSpace) * 100:f2}% full.");
                hallFull = 0;

                movieName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(studentsTickets / totalTickets) * 100:f2}% student tickets.");
            Console.WriteLine($"{(standartTickets / totalTickets) * 100:f2}% standard tickets.");
            Console.WriteLine($"{(kidsTickets / totalTickets) * 100:f2}% kids tickets.");
        }
    }
}
