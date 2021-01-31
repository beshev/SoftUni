using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> duplicateNums = new Dictionary<double, int>();
            foreach (var num in numbers)
            {
                if (duplicateNums.ContainsKey(num) == false)
                {
                    duplicateNums.Add(num, 0);
                }
                duplicateNums[num]++;
            }
            duplicateNums
                .Select(x => $"{x.Key} - {x.Value} times")
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
