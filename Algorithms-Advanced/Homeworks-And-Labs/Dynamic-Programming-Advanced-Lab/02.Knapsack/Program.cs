using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Knapsack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bagCapacity = int.Parse(Console.ReadLine());

            string input;

            var items = new List<Item>();

            while ((input = Console.ReadLine()) != "end")
            {
                var itemData = input
                    .Split(' ')
                    .ToArray();

                items.Add(new Item
                {
                    Name = itemData[0],
                    Weight = int.Parse(itemData[1]),
                    Value = int.Parse(itemData[2]),
                });
            }

            var dp = new int[items.Count + 1, bagCapacity + 1];
            var selectedItem = new bool[dp.GetLength(0), dp.GetLength(1)];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var currentItem = items[row - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var exluding = dp[row - 1, capacity];

                    if (currentItem.Weight > capacity)
                    {
                        dp[row, capacity] = exluding;
                        continue;
                    }

                    var including = currentItem.Value + dp[row - 1, capacity - currentItem.Weight];

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

            var usedItems = new SortedSet<string>();
            var totalWeight = 0;
            var maxCapacity = bagCapacity;

            for (int row = dp.GetLength(0) - 1; row >= 0; row--)
            {
                if (selectedItem[row, maxCapacity] == false)
                {
                    continue;
                }

                var item = items[row - 1];
                usedItems.Add(item.Name);
                maxCapacity -= item.Weight;
                totalWeight += item.Weight;
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {dp[items.Count, bagCapacity]}");
            Console.WriteLine(string.Join(Environment.NewLine, usedItems));
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }
}
