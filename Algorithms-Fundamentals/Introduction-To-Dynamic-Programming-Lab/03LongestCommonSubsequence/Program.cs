using System;
using System.Collections.Generic;

namespace _03LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var lcs = new int[str1.Length + 1, str2.Length + 1];
            var result = 0;

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                        result = lcs[row, col];
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                    }
                }
            }

            Console.WriteLine(result);

            // PrintSequence(str1, str2, lcs);
        }

        private static void PrintSequence(string str1, string str2, int[,] lcs)
        {
            List<char> sequence = new List<char>();

            var startRow = lcs.GetLength(0) - 1;
            var startCol = lcs.GetLength(1) - 1;

            while (startRow > 0 && startCol > 0)
            {
                if (str1[startRow - 1] == str2[startCol - 1]
                    && lcs[startRow, startCol] == lcs[startRow - 1, startCol - 1] + 1)
                {
                    sequence.Add(str1[startRow - 1]);

                    startRow--;
                    startCol--;
                }
                else if (lcs[startRow - 1, startCol] > lcs[startRow, startCol - 1])
                {
                    startRow--;
                }
                else
                {
                    startCol--;
                }
            }

            sequence.Reverse();

            Console.WriteLine(String.Join(String.Empty, sequence));
        }
    }
}
