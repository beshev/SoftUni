using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArr = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            foreach (var @char in charArr)
            {
                if (chars.ContainsKey(@char) == false)
                {
                    chars.Add(@char, 0);
                }
                chars[@char]++;
            }
            foreach (var @char in chars)
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
            }
        }
    }
}
