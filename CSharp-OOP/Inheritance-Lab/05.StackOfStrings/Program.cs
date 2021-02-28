using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());

            myStack.AddRange(new Stack<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }));
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

        }
    }
}
