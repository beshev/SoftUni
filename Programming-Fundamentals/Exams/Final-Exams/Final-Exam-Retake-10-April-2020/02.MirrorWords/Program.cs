using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            List<string> result = new List<string>();
            MatchCollection matches = Regex.Matches(someText, @"(@|#)([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1");
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    string first = match.Groups[2].Value;
                    string second = match.Groups[3].Value;
                    string secondReverse = string.Empty;
                    second.ToCharArray().Reverse().ToList().ForEach(x => secondReverse += x);
                    if (first == secondReverse)
                    {
                        result.Add($"{first} <=> {second}");
                    }
                }
                if (result.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ",result));
                    return;
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }
            Console.WriteLine("No mirror words!");
        }
    }
}
