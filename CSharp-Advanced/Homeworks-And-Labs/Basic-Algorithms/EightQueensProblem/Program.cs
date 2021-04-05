using System;
using System.IO;

namespace EightQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int side1 = int.Parse(Console.ReadLine());
            int side2 = int.Parse(Console.ReadLine());

            int[,] matrix = new int[side1, side2];
            Console.WriteLine(GetQueeens(matrix, 0));
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 1)
                    {
                        Console.Write("Q" + " ");
                    }
                    else
                    {
                        Console.Write("_" + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int GetQueeens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                Print(queens);
                return 1;
            }
            int foundWay = 0;
            for (int col = 0; col < queens.GetLength(1); col++)
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row, col] = 1;
                    foundWay += GetQueeens(queens, row + 1);
                    queens[row, col] = 0;

                }
            }
            return foundWay;
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            int maxLenght = Math.Max(queens.GetLength(0), queens.GetLength(1));
            for (int i = 1; i < maxLenght; i++)
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && queens[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(1) && queens[row, col + i] == 1)
                {
                    return false;
                }

                if ((row - i >= 0 && col - i >= 0)
                    && queens[row - i, col - i] == 1)
                {
                    return false;
                }
                if ((row - i >= 0 && col + i < queens.GetLength(1))
                    && queens[row - i, col + i] == 1)
                {
                    return false;
                }
                if ((row + i < queens.GetLength(0) && col + i < queens.GetLength(1))
                    && queens[row + i, col + i] == 1)
                {
                    return false;
                }
                if ((row + i < queens.GetLength(0) && col - i >= 0)
                    && queens[row + i, col - i] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
