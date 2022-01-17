using System;
using System.Linq;

namespace _03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToArray();


            BubbleSort(numbers);
            Console.WriteLine(String.Join(' ', numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool hasSwap = true;

            while (hasSwap)
            {
                hasSwap = false;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
                        hasSwap = true;
                    }
                }
            }
        }
    }
}
