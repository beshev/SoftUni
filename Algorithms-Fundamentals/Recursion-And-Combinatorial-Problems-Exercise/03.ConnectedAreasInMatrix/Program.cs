using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreasInMatrix
{
    internal class Program
    {
        private static char[,] field;
        private static List<Area> allAreas = new List<Area>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            field = new char[rows, cols];

            FillMatrix(rows, cols);
            FindAreas();

            var result = allAreas
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.StartRow)
                .ThenBy(x => x.StartCol)
                .ToList();

            Console.WriteLine($"Total areas found: {result.Count}");

            for (int i = 0; i < result.Count; i++)
            {
                var area = result[i];   

                Console.WriteLine($"Area #{i + 1} at ({area.StartRow}, {area.StartCol}), size: {area.Size}");
            }
        }

        static void FindAreas()
        {
            var cell = FindFreeCell();

            while (cell != (-1, -1))
            {
                var area = new Area();
                area.StartRow = cell.row;
                area.StartCol = cell.col;

                FindAreaSize(area.StartRow, area.StartCol, area);

                allAreas.Add(area);

                cell = FindFreeCell();
            }
        }

        static void FindAreaSize(int row, int col, Area area)
        {
            if (IsOutSize(row, col) || IsVisited(row, col))
            {
                return;
            }

            field[row, col] = '*';
            area.Size++;

            FindAreaSize(row, col + 1, area);
            FindAreaSize(row, col - 1, area);
            FindAreaSize(row + 1, col, area);
            FindAreaSize(row - 1, col, area);
        }

        static void FillMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentCol = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currentCol[col];
                }
            }
        }

        static (int row, int col) FindFreeCell()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == '-')
                    {
                        return (row, col);
                    }
                }
            }

            return (-1, -1);
        }

        static bool IsOutSize(int row, int col)
        {
            return row >= field.GetLength(0)
                 || col >= field.GetLength(1)
                 || row < 0
                 || col < 0;
        }

        private static bool IsVisited(int row, int col)
        {
            return field[row, col] == '*';
        }
    }

    class Area
    {
        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public int Size { get; set; }
    }
}
