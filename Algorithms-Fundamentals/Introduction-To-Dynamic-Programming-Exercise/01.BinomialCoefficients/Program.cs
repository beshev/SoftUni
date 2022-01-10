using System;
using System.Collections.Generic;

namespace _01.BinomialCoefficients
{
    internal class Program
    {
        private static Dictionary<(int row, int col), ulong> values;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            values = new Dictionary<(int row, int col), ulong>();

            Console.WriteLine(BinomialCoefficient(n, k));
        }

        private static ulong BinomialCoefficient(int row, int col)
        {
            if (values.ContainsKey((row, col)))
            {
                return values[(row, col)];
            }

            if (row <= 0 || col <= 0 || row == col)
            {
                return 1;
            }

            var result = BinomialCoefficient(row - 1, col) + BinomialCoefficient(row - 1, col - 1);
            values.Add((row, col), result);

            return result;
        }
    }
}
