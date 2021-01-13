using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>.+)<<(?<price>[0-9]+[.]?[0-9]+)!(?<quality>\d+)\b";
            List<string> furnitures = new List<string>();
            decimal totalSum = 0;
            string input = Console.ReadLine();
            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Captures.Count > 0)
                {
                    string furnitureName = match.Groups["name"].ToString();
                    decimal price = decimal.Parse(match.Groups["price"].ToString());
                    int quality = int.Parse(match.Groups["quality"].ToString());
                    furnitures.Add(furnitureName);
                    decimal currentSum = price * quality;
                    totalSum += currentSum;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in furnitures)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
