using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>
                (Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> threads = new Queue<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int task = int.Parse(Console.ReadLine());
            while (tasks.Peek() != task)
            {
                if (threads.Dequeue() >= tasks.Peek())
                {
                    tasks.Pop();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {task}");
            Console.WriteLine(string.Join(' ',threads));
        }
    }
}
