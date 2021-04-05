using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            List<string> products = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();
            while (input != "Go Shopping!")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "Urgent")
                {
                    if (!products.Contains(command[1]))
                    {
                        products.Insert(0, command[1]);
                    }
                }
                else if (command[0] == "Unnecessary")
                {
                    products.Remove(command[1]);
                }
                else if (command[0] == "Correct")
                {
                    if (products.Contains(command[1]))
                    {
                        int indexOfChange = products.IndexOf(command[1]);
                        products[indexOfChange] = command[2];
                    }
                }
                else if (command[0] == "Rearrange")
                {
                    if (products.Contains(command[1]))
                    {
                        products.Remove(command[1]);
                        products.Add(command[1]);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", products));
        }
    }
}
