using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(numArr);
            while (queue.Count > 1)
            {
                if (queue.Peek() % 2 == 0)
                {
                    Console.Write($"{queue.Dequeue()}, ");
                }
                else
                {
                    queue.Dequeue();
                }
            }
            if (queue.Peek() % 2 == 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
