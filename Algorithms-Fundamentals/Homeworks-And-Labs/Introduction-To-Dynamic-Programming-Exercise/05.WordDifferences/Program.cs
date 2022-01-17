using System;

namespace _05.WordDifferences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str2.Length + 1, str1.Length + 1];

            for (int col = 0; col < table.GetLength(1); col++)
            {
                table[0, col] = col;
            }

            for (int row = 0; row < table.GetLength(0); row++)
            {
                table[row, 0] = row;
            }


            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (str1[col - 1] == str2[row - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        table[row, col] = Math.Min(table[row, col - 1], table[row - 1, col]) + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {table[str2.Length, str1.Length]}");
        }
    }
}
