using System;
using System.Numerics;

namespace _04.BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           int p = int.Parse(Console.ReadLine());
           int result = n & ~(1 << p);
           Console.WriteLine(result);
        }
    }
}
