using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> avaibleLetterAndLenght = new Dictionary<char, int>();
            string input = Console.ReadLine();
            Match letters = Regex.Match(input, @"([#$%*&])([A-Z]+)\1");
            MatchCollection letterAsciiAndLenght = Regex.Matches(input, @"(\d{2}):(\d{2})");
            string capitalLetters = letters.Groups[2].Value;
            for (int i = 0; i < capitalLetters.Length; i++)
            {
                foreach (Match match in letterAsciiAndLenght)
                {
                    int numberOfAscii = int.Parse(match.Groups[1].Value);
                    char ascciiLetter = (char)numberOfAscii;
                    if (capitalLetters[i] == ascciiLetter)
                    {
                        // ([A]\S{3}) 
                        int lenghtOfWord = int.Parse(match.Groups[2].Value);
                        Match matchName = Regex.Match(input,$@"(\|| )({ascciiLetter}\S{{{lenghtOfWord}}}) ?\b");
                        string fullName = matchName.Groups[2].Value;
                        Console.WriteLine(fullName);
                        break;
                    }
                }
            }
        }
    }
}
