using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split();
                int index = int.Parse(command[1]);
                int powerOrValueOrRadios = int.Parse(command[2]);
                if (command[0] == "Shoot")
                {
                    ShootTheTarget(targets, index, powerOrValueOrRadios);
                }
                else if (command[0] == "Add")
                {
                    AddValue(targets, index, powerOrValueOrRadios);
                }
                else if (command[0] == "Strike")
                {
                    StrikeTargetIfIsInRangeOfRadois(targets, index, powerOrValueOrRadios);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join("|", targets));
        }

        static void ShootTheTarget(List<int> targets, int indexShoot, int powerShoot)
        {
            if (indexShoot >= 0 && indexShoot <= targets.Count - 1)
            {
                if (targets[indexShoot] - powerShoot <= 0)
                {
                    targets.RemoveAt(indexShoot);
                }
                else
                {
                    targets[indexShoot] -= powerShoot;
                }
            }
        }

        static void AddValue(List<int> targets, int indexShoot, int value)
        {
            if (indexShoot >= 0 && indexShoot <= targets.Count - 1)
            {
                targets.Insert(indexShoot, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        static void StrikeTargetIfIsInRangeOfRadois(List<int> targets, int indexShoot, int radois)
        {
            bool isInRadois = (indexShoot - radois >= 0) && (indexShoot + radois < targets.Count);
            if (isInRadois)
            {
                targets.RemoveRange(indexShoot - radois, radois + radois + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}
