using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var coins = new SortedSet<int>(input);

            var targetSum = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            var coinsCounter = 0;

            while (targetSum > 0)
            {
                if (coins.Count == 0)
                {
                    Console.WriteLine("Error");
                    return;
                }

                int currentCoin = coins.Last();
                coins.Remove(currentCoin);

                int usedCoins = targetSum / currentCoin;

                if (usedCoins == 0)
                {
                    continue;
                }

                coinsCounter += usedCoins;
                targetSum -= usedCoins * currentCoin;

                sb.AppendLine($"{usedCoins} coin(s) with value {currentCoin}");
            }

            Console.WriteLine($"Number of coins to take: {coinsCounter}");
            Console.WriteLine(sb.ToString());
        }
    }
}
