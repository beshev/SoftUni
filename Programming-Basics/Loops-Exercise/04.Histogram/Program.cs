using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;
            int group5 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    group1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    group2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    group3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    group4++;
                }
                else
                {
                    group5++;
                }

            }
            Console.WriteLine($"{group1 * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{group2 * 1.0 / n * 100:F2}%");
            Console.WriteLine($"{group3 * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{group4 * 1.0 / n * 100:F2}%");
            Console.WriteLine($"{group5 * 1.0 / n * 100:f2}%");
        }
    }
}
