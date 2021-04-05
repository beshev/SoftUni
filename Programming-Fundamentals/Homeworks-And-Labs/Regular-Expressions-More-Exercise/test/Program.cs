using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 1, 3, 4, 4, 5, 5, 7, 9, 9 };
            HashSet<int> uniqueNumbers = new HashSet<int>();
            foreach (var number in numbers)
            {
                uniqueNumbers.Add(number);
            }
        }

        static string RemoveDuplicated(string test)
        {
            for (int i = 0; i < test.Length - 1; i++)
            {
                if (test[i] == test[i + 1])
                {
                    test = test.Remove(test[i]);
                }
            }
            return test;
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
