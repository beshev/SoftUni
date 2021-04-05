using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            Console.WriteLine(String.Join(" ", nums.OrderByDescending(x => x).Take(3)));
        }
    }
}
