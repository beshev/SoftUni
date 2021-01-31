using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int toPush = numbers[0];
            int toPop = numbers[1];
            int isPresent = numbers[2];
            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int minNum = int.MaxValue;
            Stack<int> stack = new Stack<int>(input);
            if (toPop >= toPush)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                for (int i = 0; i < toPop; i++)
                {
                    stack.Pop();
                }
                while (stack.Count > 0)
                {
                    if (stack.Peek() == isPresent)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else
                    {
                        if (stack.Peek() < minNum)
                        {
                            minNum = stack.Pop();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
