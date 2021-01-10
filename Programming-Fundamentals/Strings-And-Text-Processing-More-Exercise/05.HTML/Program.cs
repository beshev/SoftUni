using System;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string cmdArg = Console.ReadLine();
            while (cmdArg != "end of comments")
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"<h1>\n    {cmdArg}\n</h1>");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"<article>\n    {cmdArg}\n</article>");
                }
                else
                {
                    Console.WriteLine($"<div>\n    {cmdArg}\n</div>");
                }
                cmdArg = Console.ReadLine();
            }
        }
    }
}
