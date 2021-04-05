using System;

namespace _06._02.MovieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int s1 = a1; s1 <= a2 - 1; s1++)
            {
                for (int s2 = 1; s2 <= n - 1; s2++)
                {
                    for (int s3 = 1; s3 <= n / 2 - 1; s3++)
                    {
                        bool point1 = s1 % 2 != 0;
                        bool point2 = (s2 + s3 + s1) % 2 != 0;
                        if (point1 && point2)
                        {
                            Console.WriteLine($"{(char)s1}-{s2}{s3}{s1}");
                        }
                    }
                }
            }
        }
    }
}
