using System;

namespace _01._01rom_Left_to_the_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long totalSum = 0;
                string[] numbers = Console.ReadLine().Split();
                long number1 = long.Parse(numbers[0]);
                long number2 = long.Parse(numbers[1]);
                if (number1 >= number2)
                {
                    for (int j = 0; j < numbers[0].Length; j++)
                    {
                        totalSum += number1 % 10;
                        number1 /= 10;
                    }
                }
                else
                {
                    for (int j = 0; j < numbers[1].Length; j++)
                    {
                        totalSum += number2 % 10;
                        number2 /= 10;
                    }
                }
                Console.WriteLine(Math.Abs(totalSum));
            }
        }
    }
}
