using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulledPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int totalBulledsShoots = bullets.Count;
            int barrel = gunBarrelSize;
            while (bullets.Count > 0)
            {
                int bullet = bullets.Pop();
                barrel--;
                int @lock = locks.Peek();
                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (barrel == 0 && bullets.Count > 0)
                {
                    barrel = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
                if (locks.Count == 0)
                {
                    int bulletsShoots = totalBulledsShoots - bullets.Count;
                    Console.WriteLine($"{bullets.Count} " +
                        $"bullets left. Earned ${valueOfIntelligence - (bulletsShoots * bulledPrice)}");
                    return;
                }
            }
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
