using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int firstSum = 0;
            int secondSum = 0;
            ReadMatrix(matrix);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstSum += matrix[row, row];
                secondSum += matrix[row, matrix.GetLength(1) - 1 - row];
            }
            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }

            static void ReadMatrix(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] rowData = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = rowData[col];
                    }
                }
            }
    }
}
