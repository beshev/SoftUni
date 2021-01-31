using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(numbers);
            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                char @operator = char.Parse(stack.Pop());
                int secondNum = int.Parse(stack.Pop());
                if (@operator == '+')
                {
                    stack.Push((firstNum + secondNum).ToString());
                }
                else if (@operator == '-')
                {
                    stack.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
