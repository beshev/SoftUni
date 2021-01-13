using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, List<double>> demons = new Dictionary<string, List<double>>();
            foreach (var demon in input)
            {
                demons.Add(demon, new List<double>() { CalcHealthOfDemon(demon), CalcDamageOfDemon(demon) });
            }
            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:f2} damage");
            }

        }

        static int CalcHealthOfDemon(string demon)
        {
            int health = 0;
            MatchCollection letters = Regex.Matches(demon, @"[^0-9+\-*\/.]");
            foreach (var item in letters)
            {
                char letter = char.Parse(item.ToString());
                health += letter;
            }
            return health;
        }

        static double CalcDamageOfDemon(string demon)
        {
            MatchCollection digits = Regex.Matches(demon, @"[+-]?[0-9]*[.]?[0-9]+");
            double damage = 0;
            foreach (var digit in digits)
            {
                damage += double.Parse(digit.ToString());
            }
            MatchCollection symbols = Regex.Matches(demon, @"[*\/]");
            foreach (var symbol in symbols)
            {
                if (symbol.ToString() == "*")
                {
                    damage *= 2;
                }
                else if (symbol.ToString() == "/")
                {
                    damage /= 2;
                }
            }
            return damage;
        }


    }
}
