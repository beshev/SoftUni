using System;

namespace _02.Num1ToN
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = num; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
