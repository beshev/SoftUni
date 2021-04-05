using System;

namespace _07.NxnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintSquare(n);
        }

        static void PrintSquare(int n) 
        {
            for (int i = 0; i < n; i++)
            {
                SquareWidth(n);
                Console.WriteLine();
            }
        }

        static void SquareWidth(int n) 
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(n + " ");
            }
        }
    }
}
