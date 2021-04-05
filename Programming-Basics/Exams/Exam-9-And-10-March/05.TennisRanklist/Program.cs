using System;

namespace _05.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int curentPoints = int.Parse(Console.ReadLine());
            double counterWin = 0;
            int tournametPoints = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string end = Console.ReadLine();
                switch (end)
                {
                    case"W":
                        counterWin++;
                        tournametPoints += 2000;
                        break;
                    case"F":
                        tournametPoints += 1200;
                        break;
                    case"SF":
                        tournametPoints += 720;
                        break;
                }


            }
            Console.WriteLine($"Final points: {curentPoints + tournametPoints}");
            Console.WriteLine($"Average points: {Math.Floor(tournametPoints * 1.0 / tournaments)}");
            Console.WriteLine($"{counterWin / tournaments * 100:F2}%");
        }
    }
}
