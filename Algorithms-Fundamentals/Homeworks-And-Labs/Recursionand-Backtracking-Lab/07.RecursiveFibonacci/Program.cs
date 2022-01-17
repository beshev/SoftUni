using System;

namespace _07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibunaci(n));
        }

        private static int GetFibunaci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return GetFibunaci(n - 1) + GetFibunaci(n - 2);
        }
    }
}
