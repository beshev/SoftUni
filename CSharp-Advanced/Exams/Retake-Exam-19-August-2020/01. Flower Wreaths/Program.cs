using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int flowersLeft = 0;
            int wreathsCount = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentSum = lilies.Pop() + roses.Dequeue();
                if (currentSum > 15)
                {
                    while (currentSum > 15)
                    {
                        currentSum -= 2;
                    }
                    if (currentSum == 15)
                    {
                        wreathsCount++;
                    }
                    else
                    {
                        flowersLeft += currentSum;
                    }
                }
                else if (currentSum == 15)
                {
                    wreathsCount++;
                }
                else
                {
                    flowersLeft += currentSum;
                }
            }
            wreathsCount += (flowersLeft / 15);
            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }
        }
    }
}
