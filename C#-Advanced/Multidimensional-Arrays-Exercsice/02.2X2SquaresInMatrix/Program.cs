using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];
            ReadMatrix(matrix);
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char firstChar = matrix[row, col];
                    char secondChar = matrix[row, col + 1];
                    char thirdChar = matrix[row + 1, col];
                    char fourthChar = matrix[row + 1, col + 1];
                    bool isValid = firstChar == secondChar && firstChar == thirdChar && firstChar == fourthChar;
                    if (isValid)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);

        }

        static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
