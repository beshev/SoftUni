using System;
using System.IO;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "Pop")
                {
                    myStack.Pop();
                }
                else
                {
                    int[] array = input
                        .Split(new string[] { "Push", ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    foreach (var integer in array)
                    {
                        myStack.Push(integer);
                    }
                }
                input = Console.ReadLine();
            }
            Printer(myStack);
            Printer(myStack);
        }

        static void Printer(Stack<int> myStack)
        {
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
