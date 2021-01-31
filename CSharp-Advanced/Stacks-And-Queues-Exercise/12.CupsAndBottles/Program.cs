using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottleArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> cupsQueue = new Queue<int>(cupsArr);
            Stack<int> bottlesStack = new Stack<int>(bottleArr);
            int wastedWater = 0;
            while (true)
            {
                int cup = cupsQueue.Peek();
                int bottle = bottlesStack.Pop();
                cup -= bottle;
                if (cup <= 0)
                {
                    wastedWater += bottle - cupsQueue.Dequeue();
                }
                else
                {
                    while (cup > 0)
                    {
                        bottle = bottlesStack.Pop();
                        if (cup - bottle <= 0)
                        {
                            wastedWater += bottle - cup;
                        }
                        cup -= bottle;
                    }
                    cupsQueue.Dequeue();
                }
                if (cupsQueue.Any() == false)
                {
                    Console.WriteLine($"Bottles: {string.Join(' ',bottlesStack)}");
                    break;
                }
                if (bottlesStack.Any() == false)
                {
                    Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
