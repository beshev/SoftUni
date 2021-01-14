using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            // [:-~!-\/]+[0-9]
            string input = Console.ReadLine().ToUpper();
            StringBuilder result = new StringBuilder();
            MatchCollection matches = Regex.Matches(input, @"[^0-9]+[0-9]+");
            HashSet<char> unique = new HashSet<char>();
            foreach (Match match in matches)
            {
                result.Append(RepadStringNTimes(match, ref unique));
            }
            Console.WriteLine($"Unique symbols used: {unique.Count}");
            if (result.Length > 0)
            {
                Console.WriteLine(result);
            }

        }


        static StringBuilder RepadStringNTimes(Match match, ref HashSet<char> unique)
        {
            string input = match.Value;
            string stringToRepead = Regex.Match(input, @"[^0-9]+").ToString();
            int repeadCount = int.Parse(Regex.Match(input, @"[0-9]+").ToString());
            if (repeadCount > 0)
            {
                foreach (var symbol in stringToRepead)
                {
                    unique.Add(symbol);
                }
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < repeadCount; i++)
            {
                result.Append(stringToRepead);
            }
            return result;
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
