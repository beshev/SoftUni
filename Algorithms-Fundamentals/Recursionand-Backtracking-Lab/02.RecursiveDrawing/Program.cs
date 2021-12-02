using System;

namespace _02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Drawing(n);
        }

        public static void Drawing(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            Drawing(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
