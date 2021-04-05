using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int toEnqueue = numbers[0];
            int toDequeue = numbers[1];
            int isPresent = numbers[2];
            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            Queue<int> queue = new Queue<int>(input);
            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int minNum = queue.Min();
                while (queue.Count > 0)
                {
                    if (queue.Dequeue() == isPresent)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                }
                Console.WriteLine(minNum);
            }

        }
    }
}
