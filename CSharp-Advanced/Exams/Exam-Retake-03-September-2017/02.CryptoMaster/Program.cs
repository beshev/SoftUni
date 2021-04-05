using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
            int[] supportArray = array.OrderBy(x => x).ToArray();
            int totalLength = 1;
            for (int i = 0; i < supportArray.Length / 2; i++)
            {
                int startIndex = array.IndexOf(supportArray[i]);
                int steps = 1;
                while (steps < array.Count)
                {
                    int counter = 1;
                    int currentStartIndex = startIndex;
                    int moveIndex = currentStartIndex + steps >= array.Count
                        ? (currentStartIndex + steps) - array.Count : currentStartIndex + steps;
                    while (array[currentStartIndex] < array[moveIndex])
                    {
                        counter++;
                        currentStartIndex = moveIndex;
                        moveIndex = currentStartIndex + steps >= array.Count
                                     ? (currentStartIndex + steps) - array.Count : currentStartIndex + steps;
                    }
                    if (counter > totalLength)
                    {
                        totalLength = counter;
                    }
                    if (totalLength >= array.Count)
                    {
                        break;
                    }
                    steps++;
                }
            }
            Console.WriteLine(totalLength);
        }
    }
}
