using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine().Split().Select(double.Parse).ToList();
            Console.WriteLine(String.Join(" ", FindingAdjacentNumbers(list)));

        }

        static List<double> FindingAdjacentNumbers(List<double> list)
        {
            List<double> adjacentNumbers = list;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    adjacentNumbers[i] = adjacentNumbers[i] + adjacentNumbers[i + 1];
                    adjacentNumbers.RemoveAt(i + 1);
                    i = -1;
                }
            }
            return adjacentNumbers;
        }
    }
}
