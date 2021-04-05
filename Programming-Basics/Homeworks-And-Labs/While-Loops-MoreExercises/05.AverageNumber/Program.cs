using System;

namespace _05.AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int averageCounter = 0;
            double sumOfNumbers = 0;

            for (int i = 0; i < num; i++)
            {
                double nums = double.Parse(Console.ReadLine());
                sumOfNumbers += nums;
                averageCounter++;
            }
            sumOfNumbers /= averageCounter;
            Console.WriteLine($"{sumOfNumbers:f2}");
        }
    }
}
