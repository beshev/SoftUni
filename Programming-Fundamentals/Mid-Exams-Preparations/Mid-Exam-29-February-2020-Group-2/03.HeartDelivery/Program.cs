using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            List<int> houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();
            int jumpIndex = 0;
            string input = Console.ReadLine();
            while (input != "Love!")
            {
                string[] command = input.Split();
                jumpIndex += int.Parse(command[1]);
                if (jumpIndex > houses.Count - 1)
                {
                    jumpIndex = 0;
                }
                if (houses[jumpIndex] == 0)
                {
                    Console.WriteLine($"Place {jumpIndex} already had Valentine's day.");
                }
                else
                {
                    houses[jumpIndex] -= 2;
                    if (houses[jumpIndex] <= 0)
                    {
                        Console.WriteLine($"Place {jumpIndex} has Valentine's day.");
                    }
                }
                input = Console.ReadLine();
            }
            int houseLeft = 0;
            foreach (var item in houses.Where(x => x > 0))
            {
                houseLeft++;
            }
            Console.WriteLine($"Cupid's last position was {jumpIndex}.");
            if (houseLeft > 0)
            {
                Console.WriteLine($"Cupid has failed {houseLeft} places.");
            }
            else
            {
                Console.WriteLine($"Mission was successful.");
            }
        }
    }
}
