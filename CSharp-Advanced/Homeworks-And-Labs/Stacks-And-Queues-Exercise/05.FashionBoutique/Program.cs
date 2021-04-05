using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int racksQuantity = int.Parse(Console.ReadLine());
            Stack<int> box = new Stack<int>(clothes);
            int racksCount = 1;
            int temp = racksQuantity;
            while (box.Count > 0)
            {
                if (racksQuantity - box.Peek() > 0)
                {
                    racksQuantity -= box.Pop();
                }
                else if (racksQuantity - box.Peek() == 0)
                {
                    box.Pop();
                    if (box.Count > 0)
                    {
                        racksCount++;
                        racksQuantity = temp;
                    }
                }
                else if (racksQuantity - box.Peek() < 0)
                {
                    racksQuantity = temp - box.Pop();
                    racksCount++;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
