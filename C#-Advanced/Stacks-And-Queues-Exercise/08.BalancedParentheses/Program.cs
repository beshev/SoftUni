using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToCharArray();
            Stack<char> stack = new Stack<char>(input);
            Queue<char> queue = new Queue<char>(input);
            bool isValid = input.Length % 2 == 0 ? true : false;
            for (int i = 0; i < input.Length / 2; i++)
            {
                int toDecrease = 0;
                switch (stack.Peek())
                {
                    case ')':
                        toDecrease = 1;
                        break;
                    case '}':
                    case ']':
                        toDecrease = 2;
                        break;
                }
                if ((queue.Dequeue() == stack.Pop() - toDecrease) == false)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
