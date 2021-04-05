using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            FillJaggetArray(matrix);
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArg = command.Split();
                string type = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);
                bool isValidCordinates = (row >= 0 && row < matrix.Length)
                    && (col >= 0 && col < matrix[row].Length);
                if (isValidCordinates)
                {
                    if (type == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (type == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                command = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        static void FillJaggetArray(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] cols = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = new int[cols.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    matrix[row][col] = cols[col];
                }
            }
        }

        static void PrintMatrix(int[][] matrix)
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
