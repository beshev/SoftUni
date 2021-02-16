using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndCols = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];
            List<string> allFlowers = new List<string>();
            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = tokens[0];
                int col = tokens[1];
                bool isInside = (row >= 0 && row < matrix.GetLength(0))
                    && (col >= 0 && col < matrix.GetLength(1));

                if (isInside)
                {
                    for (int cols = 0; cols < matrix.GetLength(0); cols++)
                    {
                        matrix[row, cols]++;
                    }
                    for (int rows = 0; rows < matrix.GetLength(1); rows++)
                    {
                        matrix[rows, col]++;
                    }
                    matrix[row, col] = 1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }
            PrintMatrix(matrix);
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
