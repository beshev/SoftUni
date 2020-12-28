using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsStrings = Console.ReadLine()
                                            .Split('|')
                                            .Reverse()
                                            .ToList();
            List<string> numbers = new List<string>();
            foreach (var str in numbersAsStrings)
            {
                numbers.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
