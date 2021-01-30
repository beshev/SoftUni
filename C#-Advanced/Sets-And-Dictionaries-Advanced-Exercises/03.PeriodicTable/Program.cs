using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicTable = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < elements.Length; j++)
                {
                    periodicTable.Add(elements[j]);
                }
            }
            Console.WriteLine(String.Join(' ',periodicTable));
        }
    }
}
