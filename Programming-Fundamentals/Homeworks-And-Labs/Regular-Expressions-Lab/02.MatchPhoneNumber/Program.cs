using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbers = Console.ReadLine();
            MatchCollection availableNumbers = Regex.Matches(phoneNumbers, @"\+359([-, ])2\1\d{3}\1\d{4}\b");
            Console.WriteLine(String.Join(", ",availableNumbers));
        }
    }
}
