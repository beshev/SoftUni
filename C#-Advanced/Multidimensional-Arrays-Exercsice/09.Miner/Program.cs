using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> commands = new Queue<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            char[,] matrix = new char[n, n];
            ReadMatrix(matrix);
            int coal = CalcCoalInMatrix(matrix);
            int[] rowAndCol = FindStartRowAndCol(matrix);
            int row = rowAndCol[0];
            int col = rowAndCol[1];

            while (commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();
                bool isEnd = false;
                if (currentCommand == "left")
                {
                    StepLeft(matrix, ref col, ref isEnd, ref row, ref coal);
                }
                else if (currentCommand == "right")
                {
                    StepRight(matrix, ref col, ref isEnd, ref row, ref coal);
                }
                else if (currentCommand == "up")
                {
                    StepUp(matrix, ref col, ref isEnd, ref row, ref coal);
                }
                else if (currentCommand == "down")
                {
                    StepDown(matrix, ref col, ref isEnd, ref row, ref coal);
                }
                if (isEnd)
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
                if (coal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }
            }
            Console.WriteLine($"{coal} coals left. ({row}, {col})");
        }

        static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        static int CalcCoalInMatrix(char[,] matrix)
        {
            int coal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coal++;
                    }
                }
            }
            return coal;
        }

        static int[] FindStartRowAndCol(char[,] matrix)
        {
            int[] rowAndCol = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        rowAndCol[0] = row;
                        rowAndCol[1] = col;
                    }
                }
            }
            return rowAndCol;
        }

        static void StepLeft(char[,] matrix, ref int col, ref bool isEnd, ref int row, ref int coal)
        {
            if (col - 1 >= 0)
            {
                col -= 1;
                if (matrix[row, col] == 'c')
                {
                    coal--;
                    matrix[row, col] = '*';
                }
                else if (matrix[row, col] == 'e')
                {
                    isEnd = true;
                }
            }
        }

        static void StepRight(char[,] matrix, ref int col, ref bool isEnd, ref int row, ref int coal)
        {
            if (col + 1 < matrix.GetLength(1))
            {
                col += 1;
                if (matrix[row, col] == 'c')
                {
                    coal--;
                    matrix[row, col] = '*';
                }
                else if (matrix[row, col] == 'e')
                {
                    isEnd = true;
                }
            }
        }

        static void StepUp(char[,] matrix, ref int col, ref bool isEnd, ref int row, ref int coal)
        {
            if (row - 1 >= 0)
            {
                row -= 1;
                if (matrix[row, col] == 'c')
                {
                    coal--;
                    matrix[row, col] = '*';
                }
                else if (matrix[row, col] == 'e')
                {
                    isEnd = true;
                }
            }
        }

        static void StepDown(char[,] matrix, ref int col, ref bool isEnd, ref int row, ref int coal)
        {
            if (row + 1 < matrix.GetLength(0))
            {
                row += 1;
                if (matrix[row, col] == 'c')
                {
                    coal--;
                    matrix[row, col] = '*';
                }
                else if (matrix[row, col] == 'e')
                {
                    isEnd = true;
                }
            }
        }
    }
}
