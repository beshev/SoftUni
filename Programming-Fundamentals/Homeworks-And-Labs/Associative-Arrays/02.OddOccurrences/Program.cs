using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => x.ToLower())
                 .ToArray();
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (var key in input)
            {
                if (count.ContainsKey(key))
                {
                    count[key]++;
                }
                else
                {
                    count.Add(key, 1);
                }
            }
            Console.WriteLine(String.Join(" ",count.Where(x => x.Value % 2 != 0).Select(x => x.Key)));
        }
    }
}
