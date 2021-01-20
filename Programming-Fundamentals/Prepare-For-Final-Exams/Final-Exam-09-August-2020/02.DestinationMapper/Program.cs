using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();
            MatchCollection matches = Regex.Matches(places, @"(=|\/)([A-Z][A-Za-z]{2,})\1");
            List<string> destinations = new List<string>();
            int points = 0;
            foreach (Match match in matches)
            {
                points += match.Groups[2].Value.Length;
                destinations.Add(match.Groups[2].Value);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
