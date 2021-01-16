using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> result = new List<int>();
            double average = array.Average();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > average)
                {
                    result.Add(array[i]);
                }
            }
            result.Sort();
            result.Reverse();
            if (result.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(String.Join(" ", result.Take(5)));
            }

        }
    }
}
