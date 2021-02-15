using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int totalSum = 0;
            while (queue.Count > 0 && stack.Count > 0)
            {
                int first = queue.Peek();
                int second = stack.Peek();
                if ((first + second) % 2 == 0)
                {
                    totalSum += (first + second);
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (totalSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
        }
    }
}
