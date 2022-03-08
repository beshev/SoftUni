using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Boxes
{
    internal class Program
    {
        static void Main()
        {
            var boxesCount = int.Parse(Console.ReadLine());

            var boxes = new int[boxesCount, 3];

            for (int row = 0; row < boxes.GetLength(0); row++)
            {
                var boxInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                boxes[row, 0] = boxInfo[0];
                boxes[row, 1] = boxInfo[1];
                boxes[row, 2] = boxInfo[2];
            }

            int maxLen = 0;
            int lastIndex = -1;

            var len = new int[boxesCount];
            var prev = new int[boxesCount];

            for (int i = 0; i < boxesCount; i++)
            {
                var bestLen = 1;
                var prevIndex = -1;

                var currentWidth = boxes[i, 0];
                var currentDepth = boxes[i, 1];
                var currentHeight = boxes[i, 2];

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevWidth = boxes[j, 0];
                    var prevDepth = boxes[j, 1];
                    var prevHeight = boxes[j, 2];

                    var isSmaller = prevWidth < currentWidth && prevDepth < currentDepth && prevHeight < currentHeight;

                    if (isSmaller && bestLen <= len[j] + 1)
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

            var lis = new List<List<int>>();

            while (lastIndex != -1)
            {
                lis.Add(new List<int>
                {
                    boxes[lastIndex, 0],
                    boxes[lastIndex, 1],
                    boxes[lastIndex, 2],
                });

                lastIndex = prev[lastIndex];
            }

            lis.Reverse();

            foreach (var box in lis)
            {
                Console.WriteLine(String.Join(' ', box));
            }
        }
    }
}
