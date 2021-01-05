using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SortedDictionary<int, int> numbers = new SortedDictionary<int, int>();
            foreach (var number in input)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
