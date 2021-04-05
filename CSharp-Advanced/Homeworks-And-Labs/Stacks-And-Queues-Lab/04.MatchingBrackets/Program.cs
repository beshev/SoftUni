using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    stack.Push(i);
                }
                else if (currentChar == ')')
                {
                    string subString = input.Substring(stack.Peek(), i - stack.Pop() + 1);
                    Console.WriteLine(subString);
                }
            }

        }
    }
}
