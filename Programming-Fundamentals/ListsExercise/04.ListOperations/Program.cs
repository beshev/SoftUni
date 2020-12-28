using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    list.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) > list.Count - 1 || int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) > list.Count - 1 || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.RemoveAt(int.Parse(command[1]));
                    }
                }
                else
                {
                    ShiftLeftOrRight(list, command[1], int.Parse(command[2]));
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", list));
        }

        static void ShiftLeftOrRight(List<int> list, string command, int moves)
        {
            if (command == "left")
            {
                for (int i = 0; i < moves; i++)
                {
                    int temp = list[0];
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[j] = list[j + 1];
                    }
                    list[list.Count - 1] = temp;

                }
            }
            else
            {
                for (int i = 0; i < moves; i++)
                {
                    int temp = list[list.Count - 1];
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[list.Count - 1 - j] = list[list.Count - 2 - j];
                    }
                    list[0] = temp;

                }
            }
        }
    }
}
