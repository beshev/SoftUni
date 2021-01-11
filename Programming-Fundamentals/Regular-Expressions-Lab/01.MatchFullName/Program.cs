using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            MatchCollection result = Regex.Matches(input,regex);
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
