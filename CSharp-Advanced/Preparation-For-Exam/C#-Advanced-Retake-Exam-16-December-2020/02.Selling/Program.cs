using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int[] startPosition = new int[2];
            List<int> portal = new List<int>();
            FillMatrix(matrix, startPosition, portal);


            int totalSum = 0;
            int row = startPosition[0];
            int col = startPosition[1];

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "right")
                {
                    if (col + 1 == matrix.GetLength(1))
                    {
                        matrix[row, col] = '-';
                        break;
                    }
                    else if (matrix[row, col + 1] == 'O')
                    {
                        portal.Remove(row);
                        portal.Remove(col + 1);

                        matrix[row, col] = '-';
                        matrix[row, col + 1] = '-';

                        row = portal[0];
                        col = portal[1];
                        matrix[row, col] = 'S';
                    }
                    else
                    {
                        if (matrix[row, col + 1] != '-')
                        {
                            totalSum += int.Parse(matrix[row, col + 1].ToString());
                        }
                        matrix[row, col] = '-';
                        col++;
                        matrix[row, col] = 'S';
                    }
                }
                else if (command == "left")
                {

                    if (col - 1 < 0)
                    {
                        matrix[row, col] = '-';
                        break;
                    }
                    else if (matrix[row, col - 1] == 'O')
                    {
                        portal.Remove(row);
                        portal.Remove(col - 1);

                        matrix[row, col] = '-';
                        matrix[row, col - 1] = '-';

                        row = portal[0];
                        col = portal[1];
                        matrix[row, col] = 'S';
                    }
                    else
                    {
                        if (matrix[row, col - 1] != '-')
                        {
                            totalSum += int.Parse(matrix[row, col - 1].ToString());
                        }
                        matrix[row, col] = '-';
                        col--;
                        matrix[row, col] = 'S';
                    }
                }
                else if (command == "up")
                {
                    if (row - 1 < 0)
                    {
                        matrix[row, col] = '-';
                        break;
                    }
                    else if (matrix[row - 1, col] == 'O')
                    {
                        portal.Remove(row - 1);
                        portal.Remove(col);

                        matrix[row, col] = '-';
                        matrix[row - 1, col] = '-';

                        row = portal[0];
                        col = portal[1];
                        matrix[row, col] = 'S';
                    }
                    else
                    {
                        if (matrix[row - 1, col] != '-')
                        {
                            totalSum += int.Parse(matrix[row - 1, col].ToString());
                        }
                        matrix[row, col] = '-';
                        row--;
                        matrix[row, col] = 'S';
                    }
                }
                else if (command == "down")
                {
                    if (row + 1 == matrix.GetLength(0))
                    {
                        matrix[row, col] = '-';
                        break;
                    }
                    else if (matrix[row + 1, col] == 'O')
                    {
                        portal.Remove(row + 1);
                        portal.Remove(col);

                        matrix[row, col] = '-';
                        matrix[row + 1, col] = '-';

                        row = portal[0];
                        col = portal[1];
                        matrix[row, col] = 'S';
                    }
                    else
                    {
                        if (matrix[row + 1, col] != '-')
                        {
                            totalSum += int.Parse(matrix[row + 1, col].ToString());
                        }
                        matrix[row, col] = '-';
                        row++;
                        matrix[row, col] = 'S';
                    }
                }

                if (totalSum >= 50)
                {
                    break;
                }
            }
            if (totalSum >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {totalSum}");
            PrintMatrix(matrix);
        }

        static void FillMatrix(char[,] matrix, int[] start, List<int> portal)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (rowData[col] == 'S')
                    {
                        start[0] = row;
                        start[1] = col;
                    }
                    if (rowData[col] == 'O')
                    {
                        portal.Add(row);
                        portal.Add(col);
                    }
                    matrix[row, col] = rowData[col];
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
