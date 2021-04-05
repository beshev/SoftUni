using System;

namespace _03.SumOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMax = int.Parse(Console.ReadLine());
            int input = int.Parse(Console.ReadLine());
            int totalSum = input;

            while (totalSum < numMax)
            {

                input = int.Parse(Console.ReadLine());
                totalSum += input;


            }
            Console.WriteLine($"{totalSum}");

        }
    }
}
