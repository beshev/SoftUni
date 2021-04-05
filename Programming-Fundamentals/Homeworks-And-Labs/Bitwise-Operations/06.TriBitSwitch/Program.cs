using System;

namespace _06.TriBitSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            long mask = (long)7 << p;
            long result = n ^ mask;
            Console.WriteLine(result);
         }
    }
}
