using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] matrix = new long[rows][];
            int count = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new long[count];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;
                if (count > 2)
                {
                    for (int col = 1; col < matrix[row].Length - 1; col++)
                    {
                        long first = matrix[row - 1][col - 1];
                        long second = matrix[row - 1][col];
                        matrix[row][col] = first + second;
                    }
                }
                count++;
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(long[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
