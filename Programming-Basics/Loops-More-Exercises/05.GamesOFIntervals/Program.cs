using System;

namespace _05.GamesOFIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int gameMoves = int.Parse(Console.ReadLine());
            double points9 = 0;
            double points19 = 0;
            double points29 = 0;
            double points39 = 0;
            double points50 = 0;
            double unvalidNums = 0;
            double totalPoints = 0;
            for (int i = 0; i < gameMoves; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                // Total Poins              
                // Point for Every Move 
                if (nums >= 0 && nums <= 9)
                {
                    points9++;
                    totalPoints += nums * 0.20;
                }
                else if (nums >= 10 && nums <= 19)
                {
                    points19++;
                    totalPoints += nums * 0.30;
                }
                else if (nums >= 20 && nums <= 29)
                {
                    points29++;
                    totalPoints += nums * 0.40;
                }
                else if (nums >= 30 && nums <= 39)
                {
                    points39++;
                    totalPoints += 50;
                }
                else if (nums >= 40 && nums <= 50)
                {
                    points50++;
                    totalPoints += 100;
                }
                else
                {
                    totalPoints /= 2;
                    unvalidNums++;
                }

            }
            // Percentage For every Nums
            points9 = (points9 / gameMoves) * 100;
            points19 = (points19 / gameMoves) * 100;
            points29 = (points29 / gameMoves) * 100;
            points39 = (points39 / gameMoves) * 100;
            points50 = (points50 / gameMoves) * 100;
            unvalidNums = (unvalidNums / gameMoves) * 100;
            // Print Output
            Console.WriteLine($"{totalPoints:f2}");
            Console.WriteLine($"From 0 to 9: {points9:f2}%");
            Console.WriteLine($"From 10 to 19: {points19:f2}%");
            Console.WriteLine($"From 20 to 29: {points29:f2}%");
            Console.WriteLine($"From 30 to 39: {points39:f2}%");
            Console.WriteLine($"From 40 to 50: {points50:f2}%");
            Console.WriteLine($"Invalid numbers: {unvalidNums:f2}%");

        }
    }
}
