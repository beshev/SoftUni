using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cables = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] table = new int[cables.Length + 1, cables.Length + 1];
            var result = 0;
            var maxCon = 0;

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    var cable = cables[row - 1];

                    if (cable == col)
                    {
                        table[row, col] = table[row - 1,col - 1] + 1;
                        result = table[row, col];

                        if (result > maxCon)
                        {
                            maxCon = result;
                        }
                    }
                    else
                    {
                        table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {maxCon}");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
