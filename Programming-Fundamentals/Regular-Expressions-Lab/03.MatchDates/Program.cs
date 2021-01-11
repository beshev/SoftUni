using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var result = Regex.Matches(input, @"(\d{2})([-,.,\/])([A-Z][a-z][a-z])\2(\d{4})");
            foreach (Match date in result)
            {
                Console.WriteLine($"Day: {date.Groups[1].Value}, Month: {date.Groups[3].Value}, Year: {date.Groups[4].Value}");
            }

        }
    }
}
