using System;

namespace _06.FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string nameWinner = "";
            int winner = int.MinValue;
            int counterMaxMovie = 0;
            while (movieName != "STOP")
            {
                counterMaxMovie++;
                int totalPoints = 0;
                int small = 0;
                int warge = 0;
                for (int i = 0; i < movieName.Length; i++)
                {
                    int points = (movieName[i]);
                    totalPoints += points;
                    if (points >= 'a' && points <= 'z')
                    {
                        small++;
                    }
                    else if (points >= 'A' && points <= 'Z')
                    {
                        warge++;
                    }
                }
                totalPoints -= (movieName.Length * 2) * small;
                totalPoints -= movieName.Length * warge;
                if (totalPoints > winner)
                {
                    winner = totalPoints;
                    nameWinner = movieName;
                }
                if (counterMaxMovie == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
                movieName = Console.ReadLine();
            }
            Console.WriteLine($"The best movie for you is {nameWinner} with {winner} ASCII sum.");
        }
    }
}
