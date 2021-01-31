using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            string[,] matrix = new string[rowsAndCols[0], rowsAndCols[1]];
            ReadMatrix(matrix);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArg.Contains("swap") && cmdArg.Length == 5)
                {
                    int row1 = int.Parse(cmdArg[1]);
                    int col1 = int.Parse(cmdArg[2]);
                    int row2 = int.Parse(cmdArg[3]);
                    int col2 = int.Parse(cmdArg[4]);
                    bool isValidCordinate = ((row1 >= 0 && row1 < matrix.GetLength(0))
                        && (col1 >= 0 && col1 < matrix.GetLength(1))) && ((row2 >= 0 && row2 < matrix.GetLength(0))
                        && (col2 >= 0 && col2 < matrix.GetLength(1)));
                    if (isValidCordinate)
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }

        static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
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
