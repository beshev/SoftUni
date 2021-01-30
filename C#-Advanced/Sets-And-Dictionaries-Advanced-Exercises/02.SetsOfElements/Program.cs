using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] lenghtOfBoth = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstLenght = int.Parse(lenghtOfBoth[0].ToString());
            int secondLenght = int.Parse(lenghtOfBoth[1].ToString());
            for (int i = 0; i < firstLenght; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < secondLenght; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            firstSet.ToList()
                .ForEach(x =>
                {
                    if (secondSet.Contains(x))
                    {
                        Console.Write($"{x} ");
                    }
                });

        }
    }
}
