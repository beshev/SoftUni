using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithLimitedCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int target = int.Parse(Console.ReadLine());
            int counter = 0;
            var sums = new HashSet<int>() { 0 };

            foreach (var coin in coins)
            {
                var newSums = new HashSet<int> { 0 };

                foreach (var sum in newSums)
                {
                    var newSum = sum + coin;

                    if (newSum == target)
                    {
                        counter++;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            Console.WriteLine(counter);
        }
    }
}
