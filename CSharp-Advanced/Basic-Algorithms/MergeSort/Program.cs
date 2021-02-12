using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrray = new int[] { 5, 8, 6, 2, 4, 1, 0 };
            Console.WriteLine(string.Join(' ',Mergesort(arrray.ToList())));
        }

        static List<int> Mergesort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> leftList = Mergesort(list.GetRange(0, middle));
            List<int> rightList = Mergesort(list.GetRange(middle,list.Count - middle));
            return CombineArray(leftList, rightList);
        }

        private static List<int> CombineArray(List<int> left,List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
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
}
