using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] table = FindLogestSubSequence(arr1, arr2);
            Stack<int> subSequence = GenerateSubSequence(table, arr1, arr2);

            Console.WriteLine(String.Join(' ', subSequence));
            Console.WriteLine(table[arr1.Length, arr2.Length]);
        }

        private static int[,] FindLogestSubSequence(int[] arr1, int[] arr2)
        {
            int[,] table = new int[arr1.Length + 1, arr2.Length + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (arr1[row - 1] == arr2[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        table[row, col] += Math.Max(table[row - 1, col], table[row, col - 1]);
                    }
                }
            }

            return table;
        }

        private static Stack<int> GenerateSubSequence(int[,] table, int[] arr1, int[] arr2)
        {
            var result = new Stack<int>();

            var startRow = table.GetLength(0) - 1;
            var startCol = table.GetLength(1) - 1;

            while (startRow > 0 && startCol >  0)
            {
                if (arr1[startRow - 1] == arr2[startCol - 1])
                {
                    result.Push(arr2[startCol - 1]);
                    startRow--;
                    startCol--;
                }
                else if (table[startRow - 1, startCol] > table[startRow, startCol - 1])
                {
                    startRow--;
                }
                else
                {
                    startCol--;
                }
            }


            return result;
        }
    }
}
