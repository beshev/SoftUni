using System;

namespace _05._02.FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            int counterWin = 0;
            int counterDraw = 0;
            int counterLose = 0;
            if (playedGames == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
                return;
            }

            for (int i = 0; i < playedGames; i++)
            {
                char end = char.Parse(Console.ReadLine());

                switch (end)
                {
                    case'W':
                        totalPoints += 3;
                        counterWin++;
                        break;
                    case'D':
                        totalPoints += 1;
                        counterDraw++;
                        break;
                    case'L':
                        counterLose++;
                        break;
                }
            }
            Console.WriteLine($"{teamName} has won {totalPoints} points during this season.");
            Console.WriteLine($"Total stats:");
            Console.WriteLine($"## W: {counterWin}");
            Console.WriteLine($"## D: {counterDraw}");
            Console.WriteLine($"## L: {counterLose}");
            Console.WriteLine($"Win rate: {counterWin / (double)playedGames * 100:f2}%");

        }
    }
}
