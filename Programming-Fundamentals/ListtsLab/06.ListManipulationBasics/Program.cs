using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<string> command = Console.ReadLine().Split().ToList();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    AddNumber(list, int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    RemoveNumber(list, int.Parse(command[1]));
                }
                else if (command[0] == "RemoveAt")
                {
                    RemuveNumberFromIdex(list, int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    InsertNumberByIdex(list, int.Parse(command[1]), int.Parse(command[2]));
                }
                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(String.Join(" ", list));
        }

        static void AddNumber(List<int> list, int numberAdd)
        {
            list.Add(numberAdd);
        }

        static void RemoveNumber(List<int> list, int remuveNumber)
        {
            list.Remove(remuveNumber);
        }

        static void RemuveNumberFromIdex(List<int> list, int index)
        {
            list.RemoveAt(index);
        }

        static void InsertNumberByIdex(List<int> list, int number, int index)
        {
            list.Insert(index, number);
        }


    }
}
