using System;
using System.Linq;

namespace _02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();


            SelectionSort(numbers);
            Console.WriteLine(String.Join(' ', numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int minIndex = i;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap
                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
        }
    }
}
