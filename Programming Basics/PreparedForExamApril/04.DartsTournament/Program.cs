using System;

namespace _04.DartsTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            int counterMoves = 0;

            while (points > 0)
            {
                counterMoves++;
                string target = Console.ReadLine();
                switch (target)
                {
                    case "bullseye":
                        Console.WriteLine($"Congratulations! You won the game with a bullseye in {counterMoves} moves!");
                        return;
                }
                int numPoints = int.Parse(Console.ReadLine());
                switch (target)
                {
                    case "number section":
                        points -= numPoints;
                        break;
                    case "double ring":
                        points -= numPoints * 2;
                        break;
                    case "triple ring":
                        points -= numPoints * 3;
                        break;                   
                }
            }
            if (points == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {counterMoves} moves!");
            }
            else
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(points)}.");
            }
        }
    }
}
