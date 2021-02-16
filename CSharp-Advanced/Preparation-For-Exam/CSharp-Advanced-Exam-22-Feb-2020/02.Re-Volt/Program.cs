using System;
using System.IO;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            bool isWon = false;
            for (int i = 0; i < commandCount; i++)
            {
                string cmd = Console.ReadLine();
                matrix[startRow, startCol] = '-';
                if (cmd == "up")
                {
                    startRow--;
                    if (startRow < 0)
                    {
                        startRow = matrix.GetLength(0) - 1;
                    }
                    if (matrix[startRow, startCol] == 'B')
                    {
                        startRow--;
                        if (startRow < 0)
                        {
                            startRow = matrix.GetLength(0) - 1;
                        }
                    }
                    if (matrix[startRow, startCol] == 'T')
                    {
                        startRow++;
                        if (startRow >= matrix.GetLength(0))
                        {
                            startRow = 0;
                        }
                    }
                }
                else if (cmd == "down")
                {
                    startRow++;
                    if (startRow >= matrix.GetLength(0))
                    {
                        startRow = 0;
                    }

                    if (matrix[startRow, startCol] == 'B')
                    {
                        startRow++;
                        if (startRow >= matrix.GetLength(0))
                        {
                            startRow = 0;
                        }

                    }
                    if (matrix[startRow, startCol] == 'T')
                    {
                        startRow--;
                        if (startRow < 0)
                        {
                            startRow = matrix.GetLength(0) - 1;
                        }
                    }
                }
                else if (cmd == "left")
                {
                    startCol--;
                    if (startCol < 0)
                    {
                        startCol = matrix.GetLength(1) - 1;
                    }
                    if (matrix[startRow, startCol] == 'B')
                    {
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol = matrix.GetLength(1) - 1;
                        }
                    }
                    if (matrix[startRow, startCol] == 'T')
                    {
                        startCol++;
                        if (startCol >= matrix.GetLength(1))
                        {
                            startCol = 0;
                        }
                    }
                }
                else if (cmd == "right")
                {
                    startCol++;
                    if (startCol >= matrix.GetLength(1))
                    {
                        startCol = 0;
                    }
                    if (matrix[startRow, startCol] == 'B')
                    {
                        startCol++;
                        if (startCol >= matrix.GetLength(1))
                        {
                            startCol = 0;
                        }
                    }
                    if (matrix[startRow, startCol] == 'T')
                    {
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol = matrix.GetLength(1) - 1;
                        }
                    }
                }
                if (matrix[startRow, startCol] == 'F')
                {
                    isWon = true;
                    matrix[startRow, startCol] = 'f';
                    break;
                }
                matrix[startRow, startCol] = 'f';
                Console.WriteLine();
            }
            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }
            Print(matrix);
        }

        static void Print(char[,] matrix)
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
