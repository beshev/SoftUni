using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
                .ToArray();
            Console.WriteLine(string.Join(' ', MergeSort(array.ToList())));
        }

        static List<T> MergeSort<T>(List<T> arr)
            where T : IComparable
        {
            if (arr.Count <= 1)
            {
                return arr;
            }
            int mid = arr.Count / 2;
            List<T> leftSide = MergeSort(arr.GetRange(0, mid));
            List<T> rightSide = MergeSort(arr.GetRange(mid, arr.Count - mid));

            return Combiner(leftSide, rightSide);
        }

        private static List<T> Combiner<T>(List<T> left, List<T> right)
            where T : IComparable
        {
            List<T> result = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) == -1)
                {
                    result.Add(left[leftIndex++]);
                }
                else if (right[rightIndex].CompareTo(left[leftIndex]) == -1)
                {
                    result.Add(right[rightIndex++]);
                }
                else
                {
                    result.Add(left[leftIndex++]);
                }
            }
            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }
            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }
            return result;
        }
    }

    public class Mergesort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (arr[mid].CompareTo(arr[mid + 1]) <= 0)
            {
                return;
            }
            for (int index = lo; index < hi + 1; index++)
            {
                aux[index] = arr[index];
            }
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i.CompareTo(mid) == 1)
                {
                    arr[k] = aux[j++];
                }
                else if (j.CompareTo(hi) == 1)
                {
                    arr[k] = aux[i++];
                }
                else if (aux[i].CompareTo(aux[j]) <= 0)
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi) //6, 5, 4, 3, 2, 1
            {
                return;
            }
            int mid = lo + (hi - lo) / 2;
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }
    }
}
