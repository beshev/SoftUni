using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] cmdArg = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int type = cmdArg[0];
                if (type == 1)
                {
                    stack.Push(cmdArg[1]);
                }
                else if (type == 2)
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else if (type == 3)
                {
                    if (stack.Count > 0) Console.WriteLine(stack.Max());
                }
                else if (type == 4)
                {
                    if (stack.Count > 0) Console.WriteLine(stack.Min());
                }
            }
            while (stack.Count > 1)
            {
                Console.Write($"{stack.Pop()}, ");
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
