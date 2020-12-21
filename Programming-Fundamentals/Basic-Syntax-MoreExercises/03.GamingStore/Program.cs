using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double totalSpen = 0;
            string nameGame = Console.ReadLine();
            while (nameGame != "Game Time")
            {
                double price = 0;
                switch (nameGame)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine($"Not Found");
                        nameGame = Console.ReadLine();
                        continue;
                }
                if (currentBalance >= price)
                {
                    totalSpen += price;
                    currentBalance -= price;
                    Console.WriteLine($"Bought {nameGame}");
                }
                else
                {
                    Console.WriteLine($"Too Expensive");
                }
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                nameGame = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalSpen:f2}. Remaining: ${currentBalance:f2}");
        }
    }
}
