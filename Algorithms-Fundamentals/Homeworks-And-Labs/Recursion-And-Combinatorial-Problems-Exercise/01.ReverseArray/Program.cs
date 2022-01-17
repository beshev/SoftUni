using System;
using System.Linq;

namespace _01.ReverseArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ReverseArr(arr, 0, arr.Length - 1);

            Console.WriteLine(String.Join(' ', arr));
        }

        static void ReverseArr(int[] arr, int firstIndex, int secondIndex)
        {
            if (firstIndex >= secondIndex)
            {
                return;
            }

            int temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;

            ReverseArr(arr, firstIndex + 1, secondIndex - 1);
        }
    }
}
