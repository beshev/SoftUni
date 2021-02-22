using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            Sam sam = new Sam();
            List<Enemy> enemies = new List<Enemy>();
            int nikolazRow = 0;
            FillMatrix(n, matrix, sam, enemies, ref nikolazRow);

            string directions = Console.ReadLine();
            for (int i = 0; i < directions.Length; i++)
            {
                foreach (var enemy in enemies)
                {
                    enemy.Move(matrix);
                }
                if (sam.CheckForFacingEnemies(matrix))
                {
                    matrix[sam.Row][sam.Col] = 'X';
                    Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                    break;
                }
                matrix[sam.Row][sam.Col] = '.';
                sam.Moves(directions[i]);
                Enemy enemyToRemove = enemies.FirstOrDefault(e => e.Row == sam.Row && e.Col == sam.Col);
                if (enemyToRemove != null)
                {
                    enemies.Remove(enemyToRemove);
                }
                matrix[sam.Row][sam.Col] = 'S';
                if (sam.CheckForNikoladze(nikolazRow))
                {
                    int nikolazCol = matrix[nikolazRow].ToList().IndexOf('N');
                    matrix[nikolazRow][nikolazCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }
            Print(matrix);
        }

        private static void FillMatrix(int n, char[][] matrix, Sam sam, List<Enemy> enemies, ref int nikolazRow)
        {
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                matrix[row] = new char[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                    if (matrix[row][col] == 'S')
                    {
                        sam.Row = row;
                        sam.Col = col;
                    }
                    if (matrix[row][col] == 'b')
                    {
                        enemies.Add(new Enemy('b', row, col));
                    }
                    if (matrix[row][col] == 'd')
                    {
                        enemies.Add(new Enemy('d', row, col));
                    }
                    if (matrix[row][col] == 'N')
                    {
                        nikolazRow = row;
                    }
                }
            }
        }

        static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }


    class Enemy
    {
        public Enemy(char side, int row, int col)
        {
            Side = side;
            Row = row;
            Col = col;
        }

        public char Side { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public void Move(char[][] matrix)
        {
            if (Side == 'b')
            {
                if (Col == matrix[Row].Length - 1)
                {
                    Side = 'd';
                    matrix[Row][Col] = Side;
                }
                else
                {
                    matrix[Row][Col] = '.';
                    Col++;
                    matrix[Row][Col] = Side;
                }

            }
            else if (Side == 'd')
            {
                if (Col == 0)
                {
                    Side = 'b';
                    matrix[Row][Col] = Side;
                }
                else
                {
                    matrix[Row][Col] = '.';
                    Col--;
                    matrix[Row][Col] = Side;
                }
            }
        }
    }

    class Sam
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public void Moves(char commnad)
        {
            if (commnad == 'U')
            {
                Row--;
            }
            else if (commnad == 'D')
            {
                Row++;
            }
            else if (commnad == 'R')
            {
                Col++;
            }
            else if (commnad == 'L')
            {
                Col--;
            }

        }

        public bool CheckForFacingEnemies(char[][] matrix)
        {
            for (int i = 0; i < Col; i++)
            {
                if (matrix[Row][i] == 'b')
                {
                    return true;
                }
            }
            for (int i = Col + 1; i < matrix[Row].Length; i++)
            {
                if (matrix[Row][i] == 'd')
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckForNikoladze(int nikolazRow)
        {
            if (Row == nikolazRow)
            {
                return true;
            }
            return false;
        }
    }
}
