using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxLen = 0;
            int lastIndex = -1;

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                var bestLen = 1;
                var prevIndex = -1;

                var currentNumber = numbers[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currentNumber && bestLen <= len[j] + 1)
                    {
                        bestLen = len[j] + 1;
                        prevIndex = j;
                    }
                }

                len[i] = bestLen;
                prev[i] = prevIndex;

                if (bestLen > maxLen)
                {
                    maxLen = bestLen;
                    lastIndex = i;
                }
            }

            var lis = new Stack<int>();

            while (lastIndex != -1)
            {
                lis.Push(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(' ', lis));
        }
    }
}
