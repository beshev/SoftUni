using System;
using System.IO;
using System.Linq;

namespace _05.Qucksort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            Quick.Sort(array);
            Console.WriteLine(string.Join(" ", array));
        }
    }

    class Quick
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort<T>(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo < hi)
            {
                int p = Partition(arr, lo, hi);
                Sort<T>(arr, lo, p);
                Sort<T>(arr, p + 1, hi);
            }
        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            T pivot = arr[(hi + lo) / 2];
            int i = lo - 1;
            int j = hi + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (arr[i].CompareTo(pivot) == -1);
                do
                {
                    j--;
                } while (arr[j].CompareTo(pivot) == 1);
                if (i.CompareTo(j) >= 0)
                {
                    return j;
                }
                else
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }
}
