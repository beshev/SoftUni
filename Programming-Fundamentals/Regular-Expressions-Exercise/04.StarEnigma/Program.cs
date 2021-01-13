using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();
            for (int i = 0; i < input; i++)
            {
                string message = Console.ReadLine();
                string descryptedMessage = DecryptMessage(message);
                Match nameAndType = Regex.Match(descryptedMessage,
                    @"@(?<name>[A-Z][a-z]+)([^@\-!:>])*:([0-9]+)([^@\-!:>])*!(?<type>[A,D])!([^@\-!:>])*->([0-9]+)");
                string name = nameAndType.Groups["name"].ToString();
                string type = nameAndType.Groups["type"].ToString();
                if (type == "A")
                {
                    attackedPlanets.Add(name);
                }
                else if (type == "D")
                {
                    destroyedPlanets.Add(name);
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            PrintThePlanets(attackedPlanets);
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            PrintThePlanets(destroyedPlanets);
        }

        static string DecryptMessage(string message)
        {

            StringBuilder decryptMessage = new StringBuilder();
            MatchCollection key = Regex.Matches(message, @"[S,T,A,R,s,t,a,r]");
            int keyCount = int.Parse(key.Count.ToString());
            for (int j = 0; j < message.Length; j++)
            {
                decryptMessage.Append((char)(message[j] - keyCount));
            }
            return decryptMessage.ToString();
        }

        static void PrintThePlanets(List<string> planets)
        {

            foreach (var planetName in planets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetName}");
            }
        }
    }
}
