using System;

namespace _07.MinimumEditDistance
{
    internal class Program
    {
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;

        static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];


            for (int row = 0; row < table.GetLength(0); row++)
            {
                table[row, 0] = row * deleteCost;
            }

            for (int col = 0; col < table.GetLength(1); col++)
            {
                table[0, col] = col * insertCost;
            }


            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        var replace = table[row - 1, col - 1] + replaceCost;
                        var insert = table[row - 1, col] + deleteCost;
                        var delete = table[row, col - 1] + insertCost;

                        table[row, col] = Math.Min(Math.Min(replace, insert), delete);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {table[str1.Length, str2.Length]}");
        }
    }
}
