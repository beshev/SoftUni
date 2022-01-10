using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DividingPresents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var totalScore = numbers.Sum();
            var sums = CalcSums(numbers);

            var bobScore = GetBobScore(sums, (int)Math.Ceiling(totalScore / 2m));
            var alanScore = totalScore - bobScore;

            var alanPresents = GetPresents(sums, alanScore);

            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int target)
        {
            var presents = new List<int>();

            while (target != 0)
            {
                presents.Add(sums[target]);

                target = target - sums[target];
            }


            return presents;
        }

        private static int GetBobScore(Dictionary<int, int> sums, int totalScore)
        {
            int bobScore = totalScore;

            while (!sums.ContainsKey(bobScore))
            {
                bobScore++;
            }

            return bobScore;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            Dictionary<int, int> allSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (int number in numbers)
            {
                var sums = allSums.Keys.ToArray();

                foreach (int sum in sums)
                {
                    var newSum = sum + number;

                    if (allSums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    allSums.Add(newSum, number);
                }
            }


            return allSums;
        }
    }
}