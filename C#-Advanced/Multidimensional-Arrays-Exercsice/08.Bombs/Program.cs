using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];
            ReadMatrix(matrix);
            int[] bombsCordinate = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < bombsCordinate.Length / 2; i++)
            {
                int row = bombsCordinate[i + i];
                int col = bombsCordinate[i + i + 1];
                int valueOfbomb = matrix[row, col];
                if (valueOfbomb > 0)
                {

                    if ((row > 0 && row < matrix.GetLength(0) - 1)
                        && (col > 0 && col < matrix.GetLength(1) - 1))
                    {
                        for (int row1 = row - 1; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if ((row > 0 && row < matrix.GetLength(0) - 1)
                        && (col == 0))
                    {
                        for (int row1 = row - 1; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }

                    }
                    else if ((row > 0 && row < matrix.GetLength(0) - 1)
                        && (col == matrix.GetLength(1) - 1))
                    {
                        for (int row1 = row - 1; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && col == 0)
                    {
                        for (int row1 = row; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && col == matrix.GetLength(1) - 1)
                    {
                        for (int row1 = row; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && (col > 0 && col < matrix.GetLength(1) - 1))
                    {
                        for (int row1 = row; row1 <= row + 1; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col == 0)
                    {
                        for (int row1 = row - 1; row1 <= row; row1++)
                        {
                            for (int col1 = col; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1)
                    {
                        for (int row1 = row - 1; row1 <= row; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1)
                    {
                        for (int row1 = row - 1; row1 <= row; row1++)
                        {
                            for (int col1 = col - 1; col1 <= col + 1; col1++)
                            {
                                if (matrix[row1, col1] > 0)
                                {
                                    matrix[row1, col1] -= valueOfbomb;
                                }
                            }
                        }
                    }
                }
            }
            int sum = 0;
            int aliveCell = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        aliveCell++;
                        sum += matrix[row,col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCell}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);

        }

        static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
