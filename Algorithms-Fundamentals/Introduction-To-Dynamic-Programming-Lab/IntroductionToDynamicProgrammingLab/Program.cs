using System;
using System.Collections.Generic;

namespace IntroductionToDynamicProgrammingLab
{
    internal class Program
    {
        private static Dictionary<int, ulong> findedFibonacci;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            findedFibonacci = new Dictionary<int, ulong>();

            Console.WriteLine(GetFibonacci(n));
        }

        private static ulong GetFibonacci(int n)
        {
            if (findedFibonacci.ContainsKey(n))
            {
                return findedFibonacci[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            findedFibonacci[n] = result;

            return result;
        }
    }
}
