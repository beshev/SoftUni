using System;

namespace _05.CruiseGames
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameGamer = Console.ReadLine();
            int numGames = int.Parse(Console.ReadLine());
            double totalPoints = 0;
            int counterVB = 0;
            int counterTS = 0;
            int counterBT = 0;
            double pointsVB = 0;
            double pointsTS = 0;
            double pointsBT = 0;

            for (int i = 0; i < numGames; i++)
            {
                string nameGame = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());
                double pointsWithPercentage = 0;

                switch (nameGame)
                {
                    case "volleyball":
                        pointsWithPercentage = points * 0.07 + points;
                        counterVB++;
                        pointsVB += pointsWithPercentage;
                        totalPoints += pointsWithPercentage;
                        break;
                    case "tennis":
                        pointsWithPercentage = points * 0.05 + points;
                        counterTS++;
                        pointsTS += pointsWithPercentage;
                        totalPoints += pointsWithPercentage;
                        break;
                    case "badminton":
                        pointsWithPercentage = points * 0.02 + points;
                        counterBT++;
                        pointsBT += pointsWithPercentage;
                        totalPoints += pointsWithPercentage;
                        break;
                }
            }
            double endVB = Math.Floor(pointsVB / counterVB);
            double endTS = Math.Floor(pointsTS / counterTS);
            double endBT = Math.Floor(pointsBT / counterBT);

            bool avarge = endBT >= 75 && endTS >= 75 && endVB >= 75;

            if (avarge)
            {
                Console.WriteLine($"Congratulations, {nameGamer}! You won the cruise games with {Math.Floor(totalPoints)} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameGamer}, you lost. Your points are only {Math.Floor(totalPoints)}.");
            }
        }
    }
}
