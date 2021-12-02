using System;

namespace _05.PathsInLabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            char[,] labyrint = new char[rows, cols];

            FillLabyrint(labyrint);

            GetAllPaths(labyrint, 0, 0);
        }

        private static void GetAllPaths(char[,] labyrint, int row, int col, string direction = "")
        {
            if (IsOutSide(labyrint, row, col) || IsVisited(labyrint, row, col) || IsWall(labyrint, row, col))
            {
                return;
            }

            if (labyrint[row, col] == 'e')
            {
                Console.WriteLine(direction);
                return;
            }

            labyrint[row, col] = 'v';

            GetAllPaths(labyrint, row, col + 1, direction + "R");
            GetAllPaths(labyrint, row + 1, col, direction + "D");
            GetAllPaths(labyrint, row, col - 1, direction + "L");
            GetAllPaths(labyrint, row - 1, col, direction + "U");

            labyrint[row, col] = '-';
        }

        private static bool IsWall(char[,] labyrint, int row, int col)
        {
            return labyrint[row, col] == '*';
        }

        private static bool IsVisited(char[,] labyrint, int row, int col)
        {
            return labyrint[row, col] == 'v';
        }

        private static bool IsOutSide(char[,] labyrint, int row, int col)
        {
            return row < 0
                || col < 0
                || row >= labyrint.GetLength(0)
                || col >= labyrint.GetLength(1);
        }

        private static void FillLabyrint(char[,] labyrint)
        {
            for (int row = 0; row < labyrint.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < labyrint.GetLength(1); col++)
                {
                    labyrint[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintLabyrint(char[,] labyrint)
        {
            for (int row = 0; row < labyrint.GetLength(0); row++)
            {
                for (int col = 0; col < labyrint.GetLength(1); col++)
                {
                    Console.Write(labyrint[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
