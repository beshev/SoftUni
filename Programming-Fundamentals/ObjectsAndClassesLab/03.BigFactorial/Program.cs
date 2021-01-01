using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial resut = new Factorial();
            Console.WriteLine(resut.PrintFactorial());
        }
    }

    class Factorial
    {
        public int numberToFantorial = int.Parse(Console.ReadLine());
        public BigInteger PrintFactorial()
        {
            BigInteger result = 1;
            for (int i = 1; i <= numberToFantorial; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
