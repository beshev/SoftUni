using System;
using System.IO;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(array, key));
        }
    }

    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
