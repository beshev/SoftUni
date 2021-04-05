using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] reversNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                reversNumbers[i] = numbers;
            }
            for (int i = 0; i < reversNumbers.Length; i++)
            {
                Console.Write(reversNumbers[reversNumbers.Length - 1 - i] + " ");
            }
        }
    }
}
