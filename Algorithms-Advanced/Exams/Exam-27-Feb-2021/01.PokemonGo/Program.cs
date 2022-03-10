using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.PokemonGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bagCapacity = int.Parse(Console.ReadLine());
            var items = new List<Street>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var itemData = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                items.Add(new Street
                {
                    Name = itemData[0],
                    PokemonCount = int.Parse(itemData[2]),
                    Length = int.Parse(itemData[1]),
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

                    if (currentItem.PokemonCount > capacity)
                    {
                        dp[row, capacity] = exluding;
                        continue;
                    }

                    var including = currentItem.Length + dp[row - 1, capacity - currentItem.PokemonCount];

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
                maxCapacity -= item.PokemonCount;
                totalWeight += item.PokemonCount;
            }

            if (usedItems.Count > 0)
            {
                Console.WriteLine(string.Join(" -> ", usedItems));
            }

            Console.WriteLine($"Total Pokemon caught -> {dp[items.Count, bagCapacity]}");
            Console.WriteLine($"Fuel Left -> {bagCapacity - totalWeight}");
        }
    }

    public class Street
    {
        public string Name { get; set; }

        public int PokemonCount { get; set; }

        public int Length { get; set; }
    }
}
