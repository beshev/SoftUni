using System;
using System.IO;
using System.Numerics;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        static BigInteger Factorial(BigInteger n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
