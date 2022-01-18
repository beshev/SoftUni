using System;

namespace _01.TBC
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            visited = new bool[rows, cols];
            matrix = ReadMatrix(rows, cols);

            var connectedTunnelsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 't' && visited[row, col] == false)
                    {
                        FindConnectedTunnels(row, col);
                        connectedTunnelsCount++;
                    }
                }
            }

            Console.WriteLine(connectedTunnelsCount);
        }

        private static void FindConnectedTunnels(int row, int col)
        {
            if (IsOutside(row, col) || IsNotATunnel(row, col) || visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            FindConnectedTunnels(row - 1, col - 1);
            FindConnectedTunnels(row + 1, col + 1);
            FindConnectedTunnels(row - 1, col + 1);
            FindConnectedTunnels(row + 1, col - 1);

            FindConnectedTunnels(row - 1, col);
            FindConnectedTunnels(row + 1, col);
            FindConnectedTunnels(row, col + 1);
            FindConnectedTunnels(row, col - 1);
        }

        private static bool IsNotATunnel(int row, int col)
        {
            return matrix[row, col] != 't';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
