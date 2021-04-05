using System;

namespace _4.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            GetTribonacciSequence(num);
        }

        static void GetTribonacciSequence(int num)
        {
            int a = 1;
            int b = 1;
            int c = 2;
            int temp = 0;
            if (num < 4)
            {
                if (num == 1)
                {
                    Console.WriteLine(a);
                }
                else if (num == 2)
                {
                    Console.WriteLine($"{a} {b}");
                }
                else if (num == 3)
                {
                    Console.WriteLine($"{a} {b} {c}");
                }
            }
            else
            {
                Console.Write($"{a} {b} {c} ");
                for (int i = 3; i < num ; i++)
                {
                    temp = a + b + c;
                    Console.Write($"{temp} ");
                    a = b;
                    b = c;
                    c = temp;
                }
            }

        }
    }
}
