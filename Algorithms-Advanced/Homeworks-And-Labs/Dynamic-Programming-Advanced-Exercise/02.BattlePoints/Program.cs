using System;
using System.Linq;

namespace _02.BattlePoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enemiesEnergy = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var battlePoints = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var energyPoints = int.Parse(Console.ReadLine());

            var dp = new int[enemiesEnergy.Length + 1, energyPoints + 1];
            var selectedItem = new bool[dp.GetLength(0), dp.GetLength(1)];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var enemyEnergy = enemiesEnergy[row - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var exluding = dp[row - 1, capacity];

                    if (enemyEnergy > capacity)
                    {
                        dp[row, capacity] = exluding;
                        continue;
                    }

                    var including = battlePoints[row - 1] + dp[row - 1, capacity - enemyEnergy];

                    if (including > exluding)
                    {
                        dp[row, capacity] = including;
                        selectedItem[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = exluding;
                    }
                }
            }

            Console.WriteLine(dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]);
        }
    }
}
