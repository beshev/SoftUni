using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();
                input.Append(cmd);
            }
            MatchCollection matches = Regex.Matches(input.ToString(),
                @"\[[^\[\]{}]*?(\d{3,})[^\[\]{}]*?]|{[^{}\[\]]*?(\d{3,})[^{}\[\]]*?}");

            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                int group = match.Groups[1].Value == string.Empty ? 2 : 1;
                if (match.Groups[group].Length % 3 == 0)
                {
                    string digits = match.Groups[group].Value;
                    for (int i = 0; i < digits.Length; i += 3)
                    {
                        int symbol = int.Parse(digits.Substring(i, 3));
                        result.Append((char)(symbol - match.Length));
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
