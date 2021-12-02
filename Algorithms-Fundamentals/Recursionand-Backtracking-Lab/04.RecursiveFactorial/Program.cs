using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(n));
        }

        private static int GetFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * GetFactorial(n - 1);
        }
    }
}
