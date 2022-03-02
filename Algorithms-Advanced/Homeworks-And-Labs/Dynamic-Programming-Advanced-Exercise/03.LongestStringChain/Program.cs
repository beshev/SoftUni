using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestStringChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var stringsAsNumbers = strings
                .Select(x => x.Length)
                .ToArray();

            int maxLen = 0;
            int lastIndex = -1;

            var len = new int[strings.Length];
            var prev = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                var bestLen = 1;
                var prevIndex = -1;

                var currentNumber = stringsAsNumbers[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = stringsAsNumbers[j];

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

            var lis = new Stack<string>();

            while (lastIndex != -1)
            {
                lis.Push(strings[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(' ', lis));
        }
    }
}
