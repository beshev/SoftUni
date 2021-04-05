using System;

namespace _02.BitAtPosition1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((n >> 1) & 1);
        }
    }
}
