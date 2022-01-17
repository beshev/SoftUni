using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.SumWithUnlimitedCoins
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

            var sums = new int[target + 1];
            sums[0] = 1;

            foreach(var coin in coins)
            {
                for (int i = 1; i < sums.Length; i++)
                {
                    if (i >= coin)
                    {
                        sums[i] += sums[i - coin];
                    }
                }
            }

            Console.WriteLine(sums[target]);
        }
    }
}
