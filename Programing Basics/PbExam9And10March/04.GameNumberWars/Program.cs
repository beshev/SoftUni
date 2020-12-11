using System;

namespace _04.GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            int pointPlayer1 = 0;
            int pointPlayer2 = 0;

            string input = Console.ReadLine();
            while (input != "End of game")
            {
                int card1 = int.Parse(input);
                int card2 = int.Parse(Console.ReadLine());
                if (card1 == card2)
                {
                    Console.WriteLine("Number wars!");
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());                                     
                    if (card1 > card2)
                    {
                        Console.WriteLine($"{player1} is winner with {pointPlayer1} points");
                        return;
                    }
                    else if (card2 > card1)
                    {
                        Console.WriteLine($"{player2} is winner with {pointPlayer2} points");
                        return;
                    }
                }
                else if (card1 > card2)
                {
                    pointPlayer1 += card1 - card2;
                }
                else if (card2 > card1)
                {
                    pointPlayer2 += card2 - card1;
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"{player1} has {pointPlayer1} points");
            Console.WriteLine($"{player2} has {pointPlayer2} points");
        }
    }
}
