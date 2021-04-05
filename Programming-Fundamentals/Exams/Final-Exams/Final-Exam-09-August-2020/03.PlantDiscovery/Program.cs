using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArg[0];
                int rarity = int.Parse(cmdArg[1]);
                Plant plant = new Plant();
                if (plants.Any(x => x.Name == name))
                {
                    plant = plants.FirstOrDefault(x => x.Name == name);
                    plant.Rarity = rarity;
                }
                else
                {
                    plant.Name = name;
                    plant.Rarity = rarity;
                    plants.Add(plant);
                }
            }
            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] cmdArg = input
                    .Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                if (command == "Rate")
                {
                    string plant = cmdArg[1];
                    if (plants.Any(x => x.Name.Contains(plant)))
                    {
                        Plant currentPlant = plants.FirstOrDefault(x => x.Name == plant);
                        double rate = double.Parse(cmdArg[2]);
                        currentPlant.AllRating.Add(rate);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Update")
                {
                    string plant = cmdArg[1];
                    if (plants.Any(x => x.Name.Contains(plant)))
                    {
                        Plant currentPlant = plants.FirstOrDefault(x => x.Name == plant);
                        int newRarity = int.Parse(cmdArg[2]);
                        currentPlant.Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Reset")
                {
                    string plant = cmdArg[1];
                    if (plants.Any(x => x.Name.Contains(plant)))
                    {
                        Plant currentPlant = plants.FirstOrDefault(x => x.Name == plant);
                        currentPlant.AllRating.RemoveAll(x => x == x);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                input = Console.ReadLine();
            }
            foreach (var item in plants.Where(x => x.AllRating.Count == 0))
            {
                item.AllRating.Add(0);
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(x => x.Rarity)
                .ThenByDescending(x => x.AllRating.Average()))
            {
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.AllRating.Average():f2}");
            }
        }
    }

    class Plant
    {
        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> AllRating { get; set; }

        public Plant()
        {
            AllRating = new List<double>();
        }
    }
}
