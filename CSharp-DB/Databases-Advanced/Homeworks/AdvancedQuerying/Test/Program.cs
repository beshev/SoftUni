namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            short n = short.Parse(Console.ReadLine());
            string someText = "";
            Stack<string> memoryStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                byte type = byte.Parse(cmdArg[0]);
                if (type == 1)
                {
                    memoryStack.Push(someText.ToString());
                    someText += string.Join(null, cmdArg.Skip(1));
                }
                else if (type == 2)
                {
                    memoryStack.Push(someText);

                    int removeCount = int.Parse(cmdArg[1]);
                    someText = string.Join(null, someText.SkipLast(removeCount));

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
                    if (memoryStack.Count >= 1)
                    {
                        someText = memoryStack.Pop();
                    }
                }
            }
        }
    }
}