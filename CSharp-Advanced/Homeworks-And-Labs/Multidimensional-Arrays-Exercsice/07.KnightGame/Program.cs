using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int totalRemove = 0;
            ReadMatrix(matrix);
            while (true)
            {
                int theBiggestAttack = 0;
                int largeAttackRow = 0;
                int largeAttackCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int attacks = GetAllAttacksOfCurrentKnight(matrix, row, col);
                        if (attacks > theBiggestAttack)
                        {
                            theBiggestAttack = attacks;
                            largeAttackCol = col;
                            largeAttackRow = row;
                        }
                    }
                }
                if (theBiggestAttack > 0)
                {
                    matrix[largeAttackRow, largeAttackCol] = '0';
                    totalRemove++;
                    continue;
                }
                break;
            }
            Console.WriteLine(totalRemove);
        }

        static void ReadMatrix(char[,] matrix)
        {
            for (int row1 = 0; row1 < matrix.GetLength(0); row1++)
            {
                string input = Console.ReadLine();
                char[] rowData = input.ToCharArray();
                for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                {
                    matrix[row1, col1] = rowData[col1];
                }
            }
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

        static int GetAllAttacksOfCurrentKnight(char[,] matrix, int row, int col)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{row + 1} {col + 2}");
            sb.Append($" {row - 1} {col + 2}");
            sb.Append($" {row + 1} {col - 2}");
            sb.Append($" {row - 1} {col - 2}");
            sb.Append($" {row - 2} {col + 1}");
            sb.Append($" {row - 2} {col - 1}");
            sb.Append($" {row + 2} {col + 1}");
            sb.Append($" {row + 2} {col - 1}");
            int counter = 0;
            if (matrix[row, col] == 'K')
            {
                Queue<int> allMoves = new Queue<int>(sb.ToString()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    );
                while (allMoves.Count > 0)
                {
                    int currentRow = allMoves.Dequeue();
                    int currentCol = allMoves.Dequeue();
                    bool isAttack = ((currentRow >= 0 && currentRow < matrix.GetLength(0))
                        && (currentCol >= 0 && currentCol < matrix.GetLength(1))
                        && matrix[currentRow, currentCol] == 'K');
                    if (isAttack)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
