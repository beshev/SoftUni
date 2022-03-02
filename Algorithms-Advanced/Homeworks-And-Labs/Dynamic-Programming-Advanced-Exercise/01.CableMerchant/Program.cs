using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CableMerchant
{
    internal class Program
    {
        private static int[] memo;
        private static int[] combo;
        private static List<int> prices;

        static void Main(string[] args)
        {
            prices = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            prices.Insert(0, 0);

            memo = new int[prices.Count];
            combo = new int[prices.Count];

            var connectorPrice = int.Parse(Console.ReadLine());

            for (int length = 1; length < prices.Count; length++)
            {
                var bestPrice = CutRod(length, connectorPrice);
                Console.Write(bestPrice + " ");
            }
        }

        private static int CutRod(int length, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (memo[length] != 0)
            {
                return memo[length];
            }

            var bestPrice = prices[length];
            var bestCombo = length;

            for (int i = 1; i < length; i++)
            {
                var price = prices[i] + CutRod(length - i, connectorPrice) - GetConnertorsCount(i) * connectorPrice;

                if (price > bestPrice)
                {
                    bestPrice = price;
                    bestCombo = i;
                }
            }

            memo[length] = bestPrice;
            combo[length] = bestCombo;
            return bestPrice;
        }

        private static int GetConnertorsCount(int length)
        {
            var count = 1;

            while (length != 0)
            {
                count++;
                length -= combo[length];
            }

            return count;
        }
    }
}
