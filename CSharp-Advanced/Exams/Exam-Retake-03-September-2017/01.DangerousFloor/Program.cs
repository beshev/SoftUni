using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8,8];
            FillMatrix(matrix);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                char type = tokens[0][0];
                int currentRow = int.Parse(tokens[0][1].ToString());
                int currentCol = int.Parse(tokens[0][2].ToString());
                int moveRow = int.Parse(tokens[1][0].ToString());
                int moveCol = int.Parse(tokens[1][1].ToString());
                if (matrix[currentRow,currentCol] != type)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (IsValidMove(type,currentRow,currentCol,moveRow,moveCol) == false)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (IsOutSide(matrix,moveRow,moveCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                matrix[currentRow, currentCol] = 'x';
                matrix[moveRow, moveCol] = type;
            }
        }

        private static bool IsValidMove(char type, int currentRow, int currentCol, int moveRow, int moveCol)
        {
            if (type == 'K')
            {
                int diffRow = Math.Abs(currentRow - moveRow);
                int diffCol = Math.Abs(currentCol - moveCol);
                if (diffRow <= 1 && diffCol <= 1)
                {
                    return true;
                }
                return false;
            }
            else if (type == 'R')
            {
                if ((currentRow == moveRow && currentCol != moveCol) ||
                    (currentRow != moveRow && currentCol == moveCol))
                {
                    return true;
                }
                return false;
            }
            else if (type == 'B')
            {
                int leftCol = currentCol - Math.Abs(currentRow - moveRow);
                int rightCol = currentCol + Math.Abs(currentRow - moveRow);
                if (currentRow != moveRow && leftCol == moveCol ||
                    (currentRow != moveRow && rightCol == moveCol))
                {
                    return true;
                }
                return false;
            }
            else if (type == 'Q')
            {
                if ((currentRow == moveRow && currentCol != moveCol) ||
                    (currentRow != moveRow && currentCol == moveCol))
                {
                    return true;
                }
                int leftCol = currentCol - Math.Abs(currentRow - moveRow);
                int rightCol = currentCol + Math.Abs(currentRow - moveRow);
                if (currentRow != moveRow && leftCol == moveCol ||
                    (currentRow != moveRow && rightCol == moveCol))
                {
                    return true;
                }
                return false;
            }
            else if(type == 'P') 
            {
                if (currentRow - moveRow == 1)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = string.Join
                    (null, Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries));
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = rowData[col];
                }
            }
        }

        public static bool IsOutSide(char[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return true;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

    }
}
