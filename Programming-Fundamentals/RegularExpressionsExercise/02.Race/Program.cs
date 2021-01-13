using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();
            var namesAndDistances = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection characters = Regex.Matches(input, @"[A-Za-z]+");
                MatchCollection digits = Regex.Matches(input, @"\d");
                string currentName = TakeNameFromRegex(characters);
                int distance = TakeDistanceFromRegex(digits);
                if (participants.Contains(currentName))
                {
                    if (namesAndDistances.ContainsKey(currentName) == false)
                    {
                        namesAndDistances.Add(currentName, 0);
                    }
                    namesAndDistances[currentName] += distance;
                }
                input = Console.ReadLine();
            }
            PrintFirstThreeWinners(namesAndDistances);
        }

        static void PrintFirstThreeWinners(Dictionary<string,int> namesAndDistances)
        {
            namesAndDistances = namesAndDistances.OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);;
            Console.WriteLine($"1st place: {namesAndDistances.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {namesAndDistances.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {namesAndDistances.Keys.ElementAt(2)}");
        }

        static string TakeNameFromRegex(MatchCollection characters)
        {
            var currentName = new StringBuilder();
            foreach (var @char in characters)
            {
                currentName.Append(@char);
            }
            return currentName.ToString();
        }

        static int TakeDistanceFromRegex(MatchCollection digits)
        {
            int distance = 0;
            foreach (var digit in digits)
            {
                distance += int.Parse(digit.ToString());
            }
            return distance;
        }
    }
}
