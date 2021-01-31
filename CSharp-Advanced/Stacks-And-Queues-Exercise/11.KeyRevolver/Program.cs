using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulledPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulledsArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bulledsStack = new Stack<int>(bulledsArr);
            int[] locksArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> locksQueue = new Queue<int>(locksArr);
            int intelligence = int.Parse(Console.ReadLine());
            int bulledCounter = 0;
            int barellCount = gunBarrel;
            while (true)
            {
                bulledCounter++;
                barellCount--;
                int bulled = bulledsStack.Pop();
                int @lock = locksQueue.Peek();
                if (bulled <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (barellCount == 0 && bulledsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barellCount = gunBarrel;
                }
                if (locksQueue.Any() == false)
                {
                    Console.WriteLine($"{bulledsStack.Count} bullets left. Earned " +
                        $"${intelligence - (bulledCounter * bulledPrice)}");
                    break;
                }
                if (bulledsStack.Any() == false)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    break;
                }
            }
        }
    }
}
