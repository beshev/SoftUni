using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[rowAndCol[0], rowAndCol[1]];
            int row = 0;
            int col = 0;
            ReadMatrix(matrix, ref row, ref col);
            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                char cmd = commands[i];
                bool isDead = false;
                bool isEscape = false;
                if (cmd == 'U')
                {
                    if (row - 1 < 0)
                    {
                        isEscape = true;
                        matrix[row, col] = '.';
                    }
                    else if (matrix[row - 1, col] == 'B')
                    {
                        isDead = true;
                        row--;
                    }
                    else
                    {
                        matrix[row - 1, col] = 'P';
                        matrix[row, col] = '.';
                        row--;
                    }
                }
                else if (cmd == 'D')
                {
                    if (row + 1 >= matrix.GetLength(0))
                    {
                        isEscape = true;
                        matrix[row, col] = '.';
                    }
                    else if (matrix[row + 1, col] == 'B')
                    {
                        isDead = true;
                        row++;
                    }
                    else
                    {
                        matrix[row + 1, col] = 'P';
                        matrix[row, col] = '.';
                        row++;
                    }
                }
                else if (cmd == 'L')
                {
                    if (col - 1 < 0)
                    {
                        isEscape = true;
                        matrix[row, col] = '.';
                    }
                    else if (matrix[row, col - 1] == 'B')
                    {
                        isDead = true;
                        col--;
                    }
                    else
                    {
                        matrix[row, col - 1] = 'P';
                        matrix[row, col] = '.';
                        col--;
                    }
                }
                else if (cmd == 'R')
                {
                    if (col + 1 >= matrix.GetLength(1))
                    {
                        isEscape = true;
                        matrix[row, col] = '.';
                    }
                    else if (matrix[row, col + 1] == 'B')
                    {
                        isDead = true;
                        col++;
                    }
                    else
                    {
                        matrix[row, col + 1] = 'P';
                        matrix[row, col] = '.';
                        col++;
                    }
                }
                BunniesSteps(matrix, CordinateOfBunnies(matrix),ref isDead);
                if (isDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {row} {col}");
                    break;
                }
                if (isEscape)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {row} {col}");
                    break;
                }
            }
        }

        static void ReadMatrix(char[,] matrix, ref int row, ref int col)
        {
            for (int row1 = 0; row1 < matrix.GetLength(0); row1++)
            {
                string input = Console.ReadLine();
                char[] rowData = input.ToCharArray();
                for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                {
                    if (rowData[col1] == 'P')
                    {
                        row = row1;
                        col = col1;
                    }
                    matrix[row1, col1] = rowData[col1];
                }
            }
        }

        static void BunniesSteps(char[,] matrix, Queue<int> cordinate, ref bool isDead)
        {
            while (cordinate.Count > 0)
            {
                int row = cordinate.Dequeue();
                int col = cordinate.Dequeue();
                if (row - 1 >= 0)
                {
                    if (matrix[row - 1, col] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[row - 1, col] = 'B';
                }
                if (row + 1 < matrix.GetLength(0))
                {
                    if (matrix[row + 1, col] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[row + 1, col] = 'B';
                }
                if (col - 1 >= 0)
                {
                    if (matrix[row, col - 1] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[row, col - 1] = 'B';
                }
                if (col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row, col + 1] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[row, col + 1] = 'B';
                }
            }
        }

        static Queue<int> CordinateOfBunnies(char[,] matrix)
        {
            Queue<int> cordinate = new Queue<int>();
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'B')
                    {
                        cordinate.Enqueue(rows);
                        cordinate.Enqueue(cols);
                    }
                }
            }
            return cordinate;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
