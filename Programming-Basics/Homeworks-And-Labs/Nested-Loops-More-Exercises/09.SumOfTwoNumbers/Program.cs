using System;

namespace _09.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counterCombinatons = 0;

            for (int num1 = start; num1 <= end; num1++)
            {
                for (int num2 = start; num2 <= end; num2++)
                {
                    int sum = num1 + num2;
                    counterCombinatons++;
                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counterCombinatons} ({num1} + {num2} = {magicNumber})");
                        return;
                    }

                }
            }
            Console.WriteLine($"{counterCombinatons} combinations - neither equals {magicNumber}");

            
        }
    }
}
