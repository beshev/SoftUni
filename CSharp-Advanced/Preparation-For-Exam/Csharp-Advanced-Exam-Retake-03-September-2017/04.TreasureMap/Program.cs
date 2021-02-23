using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input,
                    @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)");
                Match match = matches[matches.Count / 2];
                Console.WriteLine($"Go to str. {match.Groups["street"]} {match.Groups["number"]}." +
                    $" Secret pass: {match.Groups["password"]}.");
            }
        }
    }
}
