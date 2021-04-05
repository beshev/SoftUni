using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int numberMagic = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int x = start; x <= end; x++)
            {
                for (int y = start; y <= end; y++)
                {
                    counter++;
                    int sum = x + y;
                    if (sum == numberMagic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({x} + {y} = {numberMagic})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {numberMagic}");




        }
    }
}
