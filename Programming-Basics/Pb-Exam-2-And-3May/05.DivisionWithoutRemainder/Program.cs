using System;

namespace _05.DivideWhithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < quantity; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    p1 += 1;
                }
                if (num % 3 == 0)
                {
                    p2 += 1;
                }
                if (num % 4 == 0)
                {
                    p3 += 1;
                }

            }
            Console.WriteLine($"{(p1 / quantity) * 100:f2}%");
            Console.WriteLine($"{(p2 / quantity) * 100:F2}%");
            Console.WriteLine($"{(p3 / quantity) * 100:f2}%");
        }
    }
}
