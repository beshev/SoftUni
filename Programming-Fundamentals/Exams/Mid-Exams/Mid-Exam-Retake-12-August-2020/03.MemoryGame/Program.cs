using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = string.Empty;
            int moves = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();
                int index1 = int.Parse(command[0]);
                int index2 = int.Parse(command[1]);
                moves++;
                if ((index1 < 0 || index1 > list.Count - 1)
                    || (index2 < 0 || index2 > list.Count - 1))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    list.Insert(list.Count / 2, $"-{moves.ToString()}a");
                    list.Insert(list.Count / 2, $"-{moves.ToString()}a");
                }
                else if (list[index1] == list[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {list[index1]}!");
                    list.RemoveAt(Math.Min(index1, index2));
                    list.RemoveAt(Math.Max(index1, index2) - 1);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }
            }
            Console.WriteLine($"Sorry you lose :(");
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
