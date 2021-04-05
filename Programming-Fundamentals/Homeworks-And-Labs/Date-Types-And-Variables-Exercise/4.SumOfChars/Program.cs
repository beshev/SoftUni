using System;

namespace _4.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int sumOfChars = 0;
            for (int i = 0; i < n; i++)
            {
                char digit = char.Parse(Console.ReadLine());
                sumOfChars += (int)digit;
            }
            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
