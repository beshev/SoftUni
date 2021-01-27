using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];
            FillMatrix(matrix);
            int sum = int.MinValue;
            string square = string.Empty;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int colSum = matrix[row, col] + matrix[row, col + 1];
                    int rowSum = matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (colSum + rowSum > sum)
                    {
                        sum = colSum + rowSum;
                        square = $"{matrix[row, col]} {matrix[row, col + 1]}" +
                            $"\n{matrix[row + 1, col]} {matrix[row + 1, col + 1]}";
                    }
                }
            }
            Console.WriteLine($"{square}\n{sum}");
        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ")
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
