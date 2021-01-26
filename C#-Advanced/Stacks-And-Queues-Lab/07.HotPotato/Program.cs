using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                .Split();
            int count = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(kids);
            while (queue.Count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}
