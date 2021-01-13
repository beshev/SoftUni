using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            string input = Console.ReadLine();
            MatchCollection result = Regex.Matches(input,pattern);
            foreach (var email in result)
            {
                Console.WriteLine(email);
            }
        }
    }
}
