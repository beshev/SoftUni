using System;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int counter = 1;
            string direction = "right";
            int row = 0;
            int col = 0;
            for (int i = 0; i < n * n; i++)
            {
                if (direction == "right")
                {
                    while (col < n && matrix[row, col] == 0)
                    {
                        matrix[row, col] = counter;
                        counter++;
                        col++;
                    }
                    col--;
                    direction = "down";
                }
                else if (direction == "down")
                {
                    row++;
                    while (row < n && matrix[row, col] == 0)
                    {
                        matrix[row, col] = counter;
                        counter++;
                        row++;
                    }
                    row--;
                    direction = "left";
                }
                else if (direction == "left")
                {
                    col--;
                    while (col >= 0 && matrix[row, col] == 0)
                    {
                        matrix[row, col] = counter;
                        counter++;
                        col--;
                    }
                    col++;
                    direction = "up";
                }
                else if (direction == "up")
                {
                    row--;
                    while (row >= 0 && matrix[row, col] == 0)
                    {
                        matrix[row, col] = counter;
                        counter++;
                        row--;
                    }
                    row++;
                    col++;
                    direction = "right";
                }
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 10)
                    {
                        Console.Write($" {matrix[row, col]} ");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]:d2} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
