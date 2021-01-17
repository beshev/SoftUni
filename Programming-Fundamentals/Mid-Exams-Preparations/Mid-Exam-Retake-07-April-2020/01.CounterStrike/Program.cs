using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int wonsGames = 0;
            while (input != "End of battle")
            {
                int distance = int.Parse(input);
                if (energy - distance < 0)
                {
                    Console.WriteLine
                        ($"Not enough energy! Game ends with {wonsGames} won battles and {energy} energy");
                    return;
                }
                else
                {
                    wonsGames++;
                    energy -= distance;
                    if (wonsGames % 3 == 0)
                    {
                        energy += wonsGames;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wonsGames}. Energy left: {energy}");
        }
    }
}
