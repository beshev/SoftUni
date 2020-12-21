using System;

namespace _04._02.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            string input = Console.ReadLine();
            int pointsHave = 301;
            int counterSucceed = 0;
            int counterUnSucceed = 0;
            while (input != "Retire")
            {
                int points = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case "Single":
                        points = points;
                        break;
                    case "Double":
                        points = points * 2;
                        break;
                    case "Triple":
                        points = points * 3;
                        break;
                }
                if (points > pointsHave)
                {
                    counterUnSucceed++;
                }
                else
                {
                    counterSucceed++;
                    pointsHave -= points;
                }
                if (pointsHave == 0)
                {
                    Console.WriteLine($"{namePlayer} won the leg with {counterSucceed} shots.");
                    return;
                }

                input = Console.ReadLine();
            }
            if (input == "Retire")
            {
                Console.WriteLine($"{namePlayer} retired after {counterUnSucceed} unsuccessful shots.");
            }
        }
    }
}

