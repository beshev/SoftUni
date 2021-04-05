using System;

namespace _4.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string reverse = "";
            for (int i = start.Length - 1; i >= 0 ; i--)
            {
                reverse += start[i];
            }
            Console.WriteLine(reverse);
        }

    }
}
