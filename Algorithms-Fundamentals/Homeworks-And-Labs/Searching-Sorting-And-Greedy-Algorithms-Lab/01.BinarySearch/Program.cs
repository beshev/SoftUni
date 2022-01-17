using System;
using System.Linq;

namespace _01.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var searchedNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, searchedNumber));
        }

        private static int BinarySearch(int[] numbers, int searchedNumber)
        {
            var mid = numbers.Length / 2;
            var start = 0;
            var end = numbers.Length;

            while (start < end)
            {
                if (searchedNumber == numbers[mid])
                {
                    return mid;
                }

                if (searchedNumber < numbers[mid])
                {
                    end = mid - 1;
                    mid = end / 2;
                }
                else
                {
                    start = mid + 1;
                    mid = (start + end) / 2;
                }
            }

            return -1;
        }
    }
}
