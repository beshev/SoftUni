using System;

namespace _06.NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            int winnerPoints = 0;
            string nameWinner = "";
            while (namePlayer != "Stop")
            {
                int points = 0;
                for (int i = 0; i < namePlayer.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (namePlayer[i] == (Char)number)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }

                }
                if (points > winnerPoints)
                {
                    winnerPoints = points;
                    nameWinner = namePlayer;
                }
                else if (points == winnerPoints)
                {
                    winnerPoints = points;
                    nameWinner = namePlayer;
                }               
                namePlayer = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {nameWinner} with {winnerPoints} points!");
        }
    }
}
