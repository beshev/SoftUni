using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    int people = 4 - wagons[i];
                    if (peopleCount - people < 0)
                    {
                        wagons[i] += peopleCount;
                        peopleCount = 0;
                    }
                    else
                    {
                        peopleCount -= people;
                        wagons[i] += people;
                    }
                }
            }
            bool isEmpty = wagons.Any(x => x < 4);
            if (peopleCount == 0 && isEmpty)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (!isEmpty && peopleCount > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleCount} people in a queue!");
            }
            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
