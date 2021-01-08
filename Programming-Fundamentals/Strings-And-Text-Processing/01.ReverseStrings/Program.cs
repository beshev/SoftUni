using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string reverse = new string(input.Reverse().ToArray());
                Console.WriteLine($"{input} = {reverse}");

                input = Console.ReadLine();
            }
        }
    }
}
