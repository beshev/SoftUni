using System;

namespace _08.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int nums = int.Parse(Console.ReadLine());
            int sum = 0;
            int prevSum = 0;
            int diff = 0;
            int maxDiff = 0;


            // Find sum of all Pairs
            for (int i = 0; i < nums; i++)
            {
                sum += int.Parse(Console.ReadLine());
                sum += int.Parse(Console.ReadLine());

                if (i > 0)
                {
                    diff = Math.Abs(sum - prevSum);
                }
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
                prevSum = sum;
                sum = 0;

            }
            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={prevSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
