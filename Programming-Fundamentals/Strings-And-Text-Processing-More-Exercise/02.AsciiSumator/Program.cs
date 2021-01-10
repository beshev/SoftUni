using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbolOne = Char.Parse(Console.ReadLine());
            char symbolTwo = Char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int start = Math.Min(symbolOne, symbolTwo);
            int end = Math.Max(symbolOne, symbolTwo);
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > start && input[i] < end)
                {
                    sum += input[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
