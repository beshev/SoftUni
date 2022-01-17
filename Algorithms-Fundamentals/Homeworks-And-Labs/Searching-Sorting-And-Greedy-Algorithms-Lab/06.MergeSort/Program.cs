using System;
using System.Linq;

namespace _06.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();


            var result = MergeSort(numbers);
            Console.WriteLine(String.Join(' ', result));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var mergedArr = new int[left.Length + right.Length];

            var mergeIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    mergedArr[mergeIndex++] = left[leftIndex++];
                }
                else
                {
                    mergedArr[mergeIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                mergedArr[mergeIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                mergedArr[mergeIndex++] = right[rightIndex++];
            }

            return mergedArr;
        }
    }
}
