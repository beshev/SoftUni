using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int count = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    PrintPassedCars(queue, n, ref count);
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }

        static void PrintPassedCars(Queue<string> queue, int n, ref int count)
        {

            if (n > queue.Count)
            {
                while (queue.Count > 0)
                {
                    count++;
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    count++;
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                }
            }
        }
    }
}

