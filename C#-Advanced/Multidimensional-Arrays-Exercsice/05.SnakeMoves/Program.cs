using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
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
            string snake = Console.ReadLine();
            Queue<string> snakeQueue = new Queue<string>(snake.Select(x => x.ToString()));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(string[,] matrix)
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
