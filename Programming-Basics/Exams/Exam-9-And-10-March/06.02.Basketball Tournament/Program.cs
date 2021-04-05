using System;

namespace _06._02.Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournament = Console.ReadLine();
            double gameWin = 0;
            double gameLose = 0;
            double totalGames = 0;

            while (tournament != "End of tournaments")
            {
                int games = int.Parse(Console.ReadLine());
                totalGames += games;
                for (int i = 1; i <= games; i++)
                {
                    int pointDesi = int.Parse(Console.ReadLine());
                    int pointOpponents = int.Parse(Console.ReadLine());
                    if (pointDesi > pointOpponents)
                    {
                        gameWin++;
                        Console.WriteLine($"Game {i} of tournament {tournament}: win with {pointDesi - pointOpponents} points.");
                    }
                    else if (pointOpponents > pointDesi)
                    {
                        gameLose++;
                        Console.WriteLine($"Game {i} of tournament {tournament}: lost with {pointOpponents - pointDesi} points.");
                    }

                }
                tournament = Console.ReadLine();
            }
            Console.WriteLine($"{gameWin / totalGames * 100:f2}% matches win");
            Console.WriteLine($"{gameLose / totalGames * 100:F2}% matches lost");
        }
    }
}
