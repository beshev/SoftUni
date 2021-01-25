using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            input.ToList().ForEach(x => stack.Push(x.ToString()));
            Console.WriteLine(string.Join(null,stack));
        }
    }
}
