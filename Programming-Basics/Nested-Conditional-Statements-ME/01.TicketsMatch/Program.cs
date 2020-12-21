using System;

namespace _01.TicketsMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            double money = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numPeaple = int.Parse(Console.ReadLine());
            double ticketsPrice = 0;

            // Price For Transport
            if (numPeaple >= 1 && numPeaple <= 4)
            {
                money -= money * 0.75;
            }
            else if (numPeaple >= 5 && numPeaple <= 9)
            {
                money -= money * 0.6;
            }
            else if (numPeaple >= 10 && numPeaple <= 24)
            {
                money -= money * 0.5;
            }
            else if (numPeaple >= 25 && numPeaple <= 49)
            {
                money -= money * 0.40;
            }
            else
            {
                money -= money * 0.25;
            }
            // Price Left for tickets and they cant buy
            switch (category)
            {
                case "VIP":
                    ticketsPrice = numPeaple * 499.99;
                    break;
                case "Normal":
                    ticketsPrice = numPeaple * 249.99;
                    break;
            }
            if (money > ticketsPrice)
            {
                money -= ticketsPrice;
                Console.WriteLine($"Yes! You have {money:f2} leva left. ");
            }
            else
            {
                ticketsPrice -= money;
                Console.WriteLine($"Not enough money! You need {ticketsPrice:f2} leva.");
            }


        }
    }
}
