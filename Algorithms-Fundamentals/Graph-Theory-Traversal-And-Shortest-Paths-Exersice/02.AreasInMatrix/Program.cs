using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AreasInMatrix
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];

            Dictionary<char, int> areas = FindAreas();

            Console.WriteLine($"Areas: {areas.Values.Sum()}");

            foreach (var area in areas.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static Dictionary<char, int> FindAreas()
        {
            var result = new Dictionary<char, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        var areaLetter = matrix[row, col];
                        ExploreArea(row, col, areaLetter);

                        if (result.ContainsKey(areaLetter) == false)
                        {
                            result[areaLetter] = 0;
                        }

                        result[areaLetter]++;
                    }
                }
            }

            return result;
        }

        private static void ExploreArea(int startRow, int startCol, char areaLetter)
        {
            if (IsOutside(startRow, startCol)
                || IsVisited(startRow, startCol)
                || IsNotSameLetter(startRow, startCol, areaLetter))
            {
                return;
            }

            visited[startRow, startCol] = true;

            ExploreArea(startRow + 1, startCol, areaLetter);
            ExploreArea(startRow - 1, startCol, areaLetter);
            ExploreArea(startRow, startCol + 1, areaLetter);
            ExploreArea(startRow, startCol - 1, areaLetter);
        }

        private static bool IsNotSameLetter(int row, int col, char areaLetter)
        {
            return matrix[row, col] != areaLetter;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0
                    || col < 0
                    || row >= matrix.GetLength(0)
                    || col >= matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    newMatrix[row, col] = currentRow[col];
                }
            }

            return newMatrix;
        }
    }
}
