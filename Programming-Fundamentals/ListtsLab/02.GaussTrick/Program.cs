using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(String.Join(" ", GaussTrick(list)));

        }

        static List<int> GaussTrick(List<int> list)
        {
            List<int> sumsNumbers = new List<int>();
            for (int i = 0; i < list.Count / 2; i++)
            {
                sumsNumbers.Add(list[i] + list[list.Count - 1 - i]);
            }
            if (list.Count % 2 != 0)
            {
                sumsNumbers.Add(list[list.Count / 2]);
            }
            return sumsNumbers;
        }
    }
}
