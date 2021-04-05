using System;
using System.Collections.Generic;
using System.Linq;
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Contracts;


namespace _06.FoodShortage
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            HashSet<string> allBuyers = new HashSet<string>();

            AddBuyers(n, buyers);

            BuyFood(buyers);

            Console.WriteLine(buyers.Sum(x => x.Food));
        }

        private static void AddBuyers(int n, List<IBuyer> buyers)
        {
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }

            }
        }

        private static void BuyFood(List<IBuyer> buyers)
        {
            string name = Console.ReadLine();
            while (name != "End")
            {
                if (buyers.Any(x => x.Name == name))
                {
                    buyers.FirstOrDefault(x => x.Name == name).BuyFood();
                }
                name = Console.ReadLine();
            }
        }
    }
}
