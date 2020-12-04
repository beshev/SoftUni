using System;

namespace _10.EvenOrAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;    

            for (int i = 0; i < quantity; i++)
            {
                int numbs = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += numbs;
                }
                else
                {
                    sumOdd += numbs;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sumOdd}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sumOdd - sumEven)}");
            }
        }
    }
}
