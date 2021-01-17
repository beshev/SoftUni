using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int allTargets = 0;
            string commnad = string.Empty;
            while ((commnad = Console.ReadLine()) != "End")
            {
                int shootIndex = int.Parse(commnad);
                if (shootIndex > targets.Length - 1 || shootIndex < 0)
                {
                    continue;
                }
                if (targets[shootIndex] != -1)
                {
                    allTargets++;
                }
                GetTargetsAfterShoot(targets, shootIndex);
            }
            Console.WriteLine($"Shot targets: {allTargets} -> {String.Join(" ", targets)}");
        }

        static void GetTargetsAfterShoot(int[] targets, int shootIndex)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (shootIndex == i)
                {
                    continue;
                }
                if (targets[i] > targets[shootIndex] && targets[i] != -1)
                {
                    targets[i] -= targets[shootIndex];
                }
                else if (targets[i] <= targets[shootIndex] && targets[i] != -1)
                {
                    targets[i] += targets[shootIndex];
                }
            }
            targets[shootIndex] = -1;
        }
    }
}
