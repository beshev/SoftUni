using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        static void PrintTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintNumbersFrom1(i);
            }
            for (int i = n - 1; i > 0; i--)
            {
                PrintNumbersFrom1(i);
            }
        }

        static void PrintNumbersFrom1(int to)
        {
            for (int i = 1; i <= to; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
