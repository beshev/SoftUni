using System;
using System.Collections.Generic;

namespace _06.QueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> attakedRows = new HashSet<int>();
        private static HashSet<int> attakedCols = new HashSet<int>();
        private static HashSet<int> leftDiagonals = new HashSet<int>();
        private static HashSet<int> rightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            InitializeBoard(board);

            PutQueens(board);
        }

        public static void PutQueens(char[,] board, int row = 0)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                Console.WriteLine();
                return;
            }


            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (!IsAttacked(row, i))
                {
                    board[row, i] = '*';
                    attakedCols.Add(i);
                    attakedRows.Add(row);
                    leftDiagonals.Add(row - i);
                    rightDiagonals.Add(row + i);

                    PutQueens(board, row + 1);

                    board[row, i] = '-';
                    attakedCols.Remove(i);
                    attakedRows.Remove(row);
                    leftDiagonals.Remove(row - i);
                    rightDiagonals.Remove(row + i);

                }
            }
        }

        private static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsAttacked(int row, int col)
        {
            return attakedCols.Contains(col)
                || attakedRows.Contains(row)
                || leftDiagonals.Contains(row - col)
                || rightDiagonals.Contains(row + col);
        }

        private static bool IsOutSide(char[,] board, int row, int col)
        {
            return row < 0
                || col < 0
                || row >= board.GetLength(0)
                || col >= board.GetLength(1);
        }

        private static void InitializeBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '-';
                }
            }
        }
    }
}
