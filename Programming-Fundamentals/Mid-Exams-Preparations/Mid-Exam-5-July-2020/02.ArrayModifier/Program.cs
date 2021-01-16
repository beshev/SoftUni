using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                if (command[0] == "swap")
                {
                    SwapTwoElementsInArray(array, int.Parse(command[1]), int.Parse(command[2]));
                }
                else if (command[0] == "multiply")
                {
                    array[int.Parse(command[1])] = array[int.Parse(command[1])] * array[int.Parse(command[2])];
                }
                else
                {
                    DecreaseAllAlementInArrayBy1(array);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", array));
        }

        static void SwapTwoElementsInArray(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void DecreaseAllAlementInArrayBy1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= 1;
            }
        }
    }
}
