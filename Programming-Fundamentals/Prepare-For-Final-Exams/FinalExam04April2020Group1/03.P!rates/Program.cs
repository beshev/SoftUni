using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();
            string input = Console.ReadLine();
            while (input != "Sail")
            {
                string[] cmdArg = input.Split("||").ToArray();
                string city = cmdArg[0];
                int gold = int.Parse(cmdArg[2]);
                int population = int.Parse(cmdArg[1]);
                if (cities.ContainsKey(city) == false)
                {
                    cities.Add(city, new City(gold, population));
                }
                else
                {
                    cities[city].Gold += gold;
                    cities[city].Population += population;
                }
                input = Console.ReadLine();
            }
            string secondInput = Console.ReadLine();
            while (secondInput != "End")
            {
                string[] cmdArg = secondInput.Split("=>").ToArray();
                if (cmdArg[0] == "Plunder")
                {
                    PlunderTheCity(cmdArg,cities);
                }
                else if (cmdArg[0] == "Prosper")
                {
                    ProsperTheCity(cmdArg,cities);
                }
                secondInput = Console.ReadLine();
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities.OrderByDescending(c => c.Value.Gold)
                    .ThenBy(c => c.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: " +
                        $"{city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        static void PlunderTheCity(string[] cmdArg, Dictionary<string, City> cities)
        {

            string city = cmdArg[1];
            int gold = int.Parse(cmdArg[3]);
            int people = int.Parse(cmdArg[2]);
            cities[city].Gold -= gold;
            cities[city].Population -= people;
            Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
            if (cities[city].Gold <= 0 || cities[city].Population <= 0)
            {
                cities.Remove(city);
                Console.WriteLine($"{city} has been wiped off the map!");
            }
        }

        static void ProsperTheCity(string[] cmdArg, Dictionary<string, City> cities)
        {
            string city = cmdArg[1];
            int gold = int.Parse(cmdArg[2]);
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                cities[city].Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city].Gold} gold.");
            }
        }

    }

    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }
        public City(int gold, int population)
        {
            this.Gold = gold;
            this.Population = population;
        }
    }
}
