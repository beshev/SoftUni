using System;

namespace _09.LefAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int numb = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            // Find Sum Of Both Calculation
            for (int i = 0; i < numb; i++)
            {
                int numbs = int.Parse(Console.ReadLine());
                sum1 += numbs;
            }
            for (int i = 0; i < numb; i++)
            {
                int numbs = int.Parse(Console.ReadLine());
                sum2 += numbs;
            }
            // Print Output
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
            }
        }
    }
}
