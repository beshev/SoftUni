using System;
using System.Linq;

namespace _01.RodCutting
{
    internal class Program
    {
        private static int[] memo;
        private static int[] combo;
        private static int[] prices;
        static void Main(string[] args)
        {
            prices = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            memo = new int[prices.Length];
            combo = new int[prices.Length];

            var length = int.Parse(Console.ReadLine());

            var bestPrice = CutRod(length);

            Console.WriteLine(bestPrice);

            while (length != 0)
            {
                Console.Write($"{combo[length]} ");
                length -= combo[length];
            }
        }

        private static int CutRod(int length)
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
                var price = prices[i] + CutRod(length - i);

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
    }
}
