using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmdArg = command.Split().ToArray();
                string type = cmdArg[0];
                if (type == "add")
                {
                    stack.Push(int.Parse(cmdArg[1]));
                    stack.Push(int.Parse(cmdArg[2]));
                }
                else if (type == "remove")
                {
                    int countToRemove = int.Parse(cmdArg[1]);
                    if (countToRemove <= stack.Count)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
