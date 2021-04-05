using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GreedyTimes
{

    class Program
    {
        static string gold = "Gold";
        static string cash = "Cash";
        static string gem = "Gem";

        static void Main(string[] args)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>(comparer);
            bag.Add(gold, new Dictionary<string, long>(comparer) { { "Gold", 0 } });
            bag.Add(gem, new Dictionary<string, long>(comparer));
            bag.Add(cash, new Dictionary<string, long>(comparer));

            long bagCapacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length / 2; i++)
            {
                string type = input[i + i];
                long value = long.Parse(input[i + i + 1]);
                long gemSum = bag[gem].Sum(x => x.Value);
                long goldSum = bag[gold].Sum(v => v.Value);
                long cashSum = bag[cash].Sum(x => x.Value);
                long totalSum = gemSum + goldSum + cashSum;
                if (totalSum + value > bagCapacity)
                {
                    continue;
                }
                if (type.Length == 3)
                {
                    if (cashSum + value <= gemSum)
                    {
                        if (bag[cash].ContainsKey(type) == false)
                        {
                            bag[cash].Add(type, 0);
                        }
                        bag[cash][type] += value;
                    }
                }
                else if (type.ToLower() == "gold")
                {
                    bag[gold]["Gold"] += value;
                }
                else if (type.ToLower().EndsWith("gem"))
                {
                    if (gemSum + value <= goldSum)
                    {
                        if (bag[gem].ContainsKey(type) == false)
                        {
                            bag[gem].Add(type, 0);
                        }
                        bag[gem][type] += value;
                    }
                }
            }

            bag[gold] = bag[gold].Where(x => x.Value > 0).ToDictionary(k => k.Key, v => v.Value);
            bag[cash] = bag[cash].Where(x => x.Value > 0).ToDictionary(k => k.Key, v => v.Value);
            bag[gem] = bag[gem].Where(x => x.Value > 0).ToDictionary(k => k.Key, v => v.Value);

            foreach (var type in bag.Where(x => x.Value.Sum(x => x.Value) > 0))
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Sum(x => x.Value)}");
                foreach (var item in type.Value.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        static long TotalSumOfBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            return bag.Sum(x => x.Value.Sum(v => v.Value));
        }
    }
}
