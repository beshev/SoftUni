using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (world.ContainsKey(cmdArg[0]) == false)
                {
                    world.Add(cmdArg[0], new Dictionary<string, List<string>>());
                }
                if (world[cmdArg[0]].ContainsKey(cmdArg[1]) == false)
                {
                    world[cmdArg[0]].Add(cmdArg[1],new List<string>());
                }
                world[cmdArg[0]][cmdArg[1]].Add(cmdArg[2]);
            }

            foreach (var country in world)
            {
                Console.WriteLine($"{country.Key}:");
                foreach (var city in country.Value)
                {
                    Console.WriteLine($"{city.Key} -> {string.Join(", ",city.Value)}");
                }
            }
        }
    }
}
