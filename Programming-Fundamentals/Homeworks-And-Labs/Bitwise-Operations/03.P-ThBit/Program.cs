using System;

namespace _03.P_ThBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine((n >> p) & 1);
        }
    }
}
