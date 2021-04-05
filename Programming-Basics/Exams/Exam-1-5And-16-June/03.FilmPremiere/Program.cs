using System;

namespace _03.FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string meal = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());
            double sumForOne = 0;

            switch (movie)
            {
                case "John Wick":
                    switch (meal)
                    {
                        case "Drink":
                            sumForOne = 12;
                            break;
                        case "Popcorn":
                            sumForOne = 15;
                            break;
                        case "Menu":
                            sumForOne = 19;
                            break;
                    }
                    break;
                case "Star Wars":
                    switch (meal)
                    {
                        case "Drink":
                            sumForOne = 18;
                            break;
                        case "Popcorn":
                            sumForOne = 25;
                            break;
                        case "Menu":
                            sumForOne = 30;
                            break;
                    }
                    break;
                case "Jumanji":
                    switch (meal)
                    {
                        case "Drink":
                            sumForOne = 9;
                            break;
                        case "Popcorn":
                            sumForOne = 11;
                            break;
                        case "Menu":
                            sumForOne = 14;
                            break;
                    }
                    break;
            }
            if (movie == "Star Wars" && numTickets >=4)
            {
                sumForOne -= sumForOne * 0.3;
                sumForOne *= numTickets;
            }
            else if (movie == "Jumanji" && numTickets == 2)
            {
                sumForOne -= sumForOne * 0.15;
                sumForOne *= numTickets;
            }
            else
            {
                sumForOne *= numTickets;
            }
            Console.WriteLine($"Your bill is {sumForOne:f2} leva.");
        }
    }
}
