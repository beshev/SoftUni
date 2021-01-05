using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    list.Add(int.Parse(command[1]));
                }
                else
                {
                    FitTheList(list, int.Parse(command[0]), maxCapacity);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", list));
        }

        static void FitTheList(List<int> list , int numberAdd,int maxCapacity)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] + numberAdd <= maxCapacity)
                {
                    list[i] += numberAdd;
                    break;
                }
            }

        }
    }
}
