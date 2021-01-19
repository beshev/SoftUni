using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MatchCollection digits = Regex.Matches(input, @"\d");
            BigInteger threshold = MultiplyingAllDigits(digits);
            MatchCollection emojis = Regex.Matches(input, @"(::|\*\*)([A-Z][a-z]{2,})(\1)");
            List<string> passedEmojis = new List<string>();
            foreach (Match emoji in emojis)
            {
                string onlyLetters = emoji.Groups[2].Value;
                char[] charArr = onlyLetters.ToCharArray();
                BigInteger sumOfEmoji = charArr.Sum(c => c);
                if (sumOfEmoji > threshold)
                {
                    passedEmojis.Add(emoji.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            if (emojis.Count > 0)
            {
                Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
                if (passedEmojis.Count > 0)
                {
                    Console.WriteLine(String.Join(Environment.NewLine, passedEmojis));
                }
            }
        }

        static BigInteger MultiplyingAllDigits(MatchCollection digits)
        {
            BigInteger sum = 1;
            foreach (Match match in digits)
            {
                int digit = int.Parse(match.ToString());
                sum = sum * digit;
            }
            return sum;
        }
    }
}
