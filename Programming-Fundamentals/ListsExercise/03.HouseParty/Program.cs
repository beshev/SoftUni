using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] commnad = Console.ReadLine().Split();
                AddPersonOnListOrNot(list, commnad[2], commnad[0]);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void AddPersonOnListOrNot(List<string> list, string command, string name)
        {
            if (command == "going!")
            {
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
                else
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
            }
            else
            {
                if (list.Contains(name))
                {
                    list.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }

            }
        }
    }
}
