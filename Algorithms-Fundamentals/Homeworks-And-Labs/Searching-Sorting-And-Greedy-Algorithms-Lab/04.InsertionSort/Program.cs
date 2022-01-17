using System;
using System.Linq;

namespace _04.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();


            InsertionSort(numbers);
            Console.WriteLine(String.Join(' ', numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int index = i;

                while (index > 0 && numbers[index] < numbers[index - 1])
                {
                    (numbers[index], numbers[index - 1]) = (numbers[index - 1], numbers[index--]);
                }
            }
        }
    }
}
