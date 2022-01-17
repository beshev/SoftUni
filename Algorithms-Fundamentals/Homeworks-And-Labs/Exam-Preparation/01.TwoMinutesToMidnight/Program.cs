using System;
using System.Collections.Generic;

namespace _01.TwoMinutesToMidnight
{
    internal class Program
    {
        private static Dictionary<string, ulong> memo;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            memo = new Dictionary<string, ulong>();

            ulong binom = GetBinom(n, k);

            Console.WriteLine(binom);
        }

        private static ulong GetBinom(int row, int col)
        {
            if (row < 1 || col < 1 || row == col)
            {
                return 1;
            }

            var id = $"{row}-{col}";

            if (memo.ContainsKey(id))
            {
                return memo[id];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            memo[id] = result;

            return result;
        }
    }
}
