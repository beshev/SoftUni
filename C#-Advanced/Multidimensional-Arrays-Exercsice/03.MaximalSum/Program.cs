using System;
using System.Linq;

namespace _03.MaximalSum
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
            ReadMatrix(matrix);
            int sum = int.MinValue;
            int[,] miniMatrix = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int[] digitsArr = new int[]
                    {
                        matrix[row,col],
                        matrix[row,col + 1],
                        matrix[row,col + 2],
                        matrix[row+ 1,col],
                        matrix[row+ 1,col + 1],
                        matrix[row+ 1,col+ 2],
                        matrix[row+ 2,col],
                        matrix[row+ 2,col+ 1],
                        matrix[row+ 2,col + 2],
                    };
                    if (digitsArr.Sum() > sum)
                    {
                        sum = digitsArr.Sum();
                        miniMatrix = new int[,]
                        {
                            { matrix[row,col],matrix[row,col + 1],matrix[row,col + 2]},
                            { matrix[row+ 1,col],matrix[row+ 1,col + 1],matrix[row+ 1,col+ 2]},
                            { matrix[row+ 2,col],matrix[row+ 2,col+ 1],matrix[row+ 2,col + 2]}
                        };
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            PrintMatrix(miniMatrix);
        }

        static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
