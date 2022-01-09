using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MoveDownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();
            int[,] matrixWithSums = CalcMatrixSums(matrix);

            Stack<string> result = FindPathOfMaxSum(matrixWithSums);

            Console.WriteLine(String.Join(' ', result));
        }

        private static Stack<string> FindPathOfMaxSum(int[,] matrixWithSums)
        {
            int startRow = matrixWithSums.GetLength(0) - 1;
            int startCol = matrixWithSums.GetLength(1) - 1;

            Stack<string> result = new Stack<string>();
            result.Push($"[{startRow}, {startCol}]");

            while (startRow > 0 && startCol > 0)
            {
                if (matrixWithSums[startRow - 1, startCol] > matrixWithSums[startRow, startCol - 1])
                {
                    startRow--;
                }
                else
                {
                    startCol--;
                }

                result.Push($"[{startRow}, {startCol}]");
            }

            while (startRow > 0)
            {
                startRow--;
                result.Push($"[{startRow}, {startCol}]");
            }

            while (startCol > 0)
            {
                startCol--;
                result.Push($"[{startRow}, {startCol}]");
            }

            return result;
        }

        private static int[,] CalcMatrixSums(int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            result[0, 0] = matrix[0, 0];

            for (int row = 1; row < result.GetLength(0); row++)
            {
                result[row, 0] = matrix[row, 0] + result[row - 1, 0];
            }

            for (int col = 1; col < result.GetLength(1); col++)
            {
                result[0, col] = matrix[0, col] + result[0, col - 1];
            }

            for (int row = 1; row < result.GetLength(0); row++)
            {
                for (int col = 1; col < result.GetLength(1); col++)
                {
                    int maxNum = Math.Max(result[row - 1, col], result[row, col - 1]);
                    result[row, col] = maxNum + matrix[row, col];
                }
            }

            return result;
        }

        private static int[,] ReadMatrix()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowLine[col];
                }
            }

            return matrix;
        }
    }
}
