using System;
using System.Collections.Generic;

namespace ImplementingStackAndList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            CustomStack stack = new CustomStack(arr);
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
                if (stack.Count % 2 != 0)
                {
                    Console.WriteLine("You popped even number");
                }
                else
                {
                    Console.WriteLine("You popped odd number");
                }
            }
        }
    }
}
