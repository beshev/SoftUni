using System;

namespace _07.NChooseKCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Console.WriteLine(Binomial(row, col));
        }

        private static int Binomial(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return Binomial(row - 1, col) + Binomial(row - 1, col - 1);
        }
    }
}
