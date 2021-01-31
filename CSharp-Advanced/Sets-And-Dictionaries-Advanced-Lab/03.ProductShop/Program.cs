using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] cmdArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = cmdArg[0];
                string product = cmdArg[1];
                double price = double.Parse(cmdArg[2]);
                if (shops.ContainsKey(shop) == false)
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (shops[shop].ContainsKey(product) == false)
                {
                    shops[shop].Add(product,price);
                }
                input = Console.ReadLine();
            }
            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
