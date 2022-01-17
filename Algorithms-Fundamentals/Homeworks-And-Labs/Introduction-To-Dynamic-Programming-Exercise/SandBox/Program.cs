using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    internal class Program
    {
        private static int[] numbers;
        private static int totalHalf;

        private static int[,] matrix;
        private static bool[,] usedMatrix;

        public static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int total = numbers.Sum();
            totalHalf = (int)Math.Floor((decimal)total / 2);

            int rows = numbers.Length;
            int cols = totalHalf;

            matrix = new int[rows + 1, cols + 1];
            usedMatrix = new bool[rows, cols];

            for (int row = 1; row < rows + 1; row++)
            {
                for (int col = 1; col < cols + 1; col++)
                {
                    int include = -1;
                    if (numbers[row - 1] <= col)
                    {
                        include = numbers[row - 1] + matrix[row - 1, col - numbers[row - 1]];
                    }

                    int exclude = matrix[row - 1, col];

                    if (include > exclude)
                    {
                        //include the number
                        matrix[row, col] = include;
                        usedMatrix[row - 1, col - 1] = true;
                    }
                    else
                    {
                        //exclude the number
                        matrix[row, col] = exclude;
                    }
                }
            }

            List<int> result = new List<int>();

            int currentRow = rows - 1;
            int currentCol = cols - 1;

            while (currentRow >= 0 && currentCol >= 0)
            {
                if (usedMatrix[currentRow, currentCol])
                {
                    result.Add(numbers[currentRow]);
                    currentCol -= numbers[currentRow];
                }
                currentRow--;
            }

            int alanSum = result.Sum();
            int bobSum = Math.Abs(total - alanSum);

            Console.WriteLine($"Difference: {Math.Abs(alanSum - bobSum)}");
            Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ", result)}");
            Console.WriteLine($"Bob takes the rest.");
        }
    }
}