using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int sumAll = 0;
            // Find The Large Number and Sumall
            for (int i = 0; i < num; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                sumAll += nums;

                if (nums > maxNum)
                {
                    maxNum = nums;
                }
                
            }
            // Find SumAll = MaxNumer
            sumAll -= maxNum;
            if (maxNum == sumAll)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            // Find different between MaxNuber and Sum of Onothers Numbers
            else 
            {
                sumAll -= maxNum;
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sumAll)}");


            }

        }
    }
}
