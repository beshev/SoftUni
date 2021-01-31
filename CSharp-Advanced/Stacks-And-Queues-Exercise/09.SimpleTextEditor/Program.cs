using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string someText = string.Empty;
            Stack<string> memoryStack = new Stack<string>();
            memoryStack.Push(someText);
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                int type = int.Parse(cmdArg[0]);
                if (type == 1)
                {
                    someText += cmdArg[1];
                    memoryStack.Push(someText);
                }
                else if (type == 2)
                {
                    int startIndex = someText.Length - int.Parse(cmdArg[1]);
                    if (startIndex >= 0 && startIndex < someText.Length)
                    {
                        someText = someText.Remove(startIndex);
                        memoryStack.Push(someText);
                    }
                }
                else if (type == 3)
                {
                    int index = int.Parse(cmdArg[1]) - 1;
                    if (index >= 0 && index < someText.Length)
                    {
                        Console.WriteLine(someText[index]);
                    }
                }
                else if (type == 4)
                {
                    if (memoryStack.Count > 1)
                    {
                        memoryStack.Pop();
                        someText = memoryStack.Peek();
                    }
                }
            }
        }
    }
}
