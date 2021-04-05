using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string location = Console.ReadLine();
        string input = Console.ReadLine();
        List<string> allTickets = new List<string>();
        MatchCollection matches1 = Regex.Matches(input,
            @"{[^{]*?\[([A-Z]{3} [A-Z]{2})\][^{}]*?\[(?<seats>[A-Z]{1}\d{1,2})\][^}]*?}|\[[^\[]*?\{([A-Z]{3} [A-Z]{2})\}[^\[\]]*?\{(?<seats>[A-Z]{1}\d{1,2})\}[^\[\]]*?\]");
        string[] seats = matches1.Select(x => x.Groups["seats"].Value).ToArray();
        if (seats.Length > 2)
        {
            seats = seats.GroupBy(s => s.Substring(1))
                .Where(g => g.Count() > 1)
                .Select(g => g.ToArray())
                .First();
        }
        Console.WriteLine($"You are traveling to {location} on seats {allTickets[0]} and {allTickets[1]}.");
    }

    static List<string> GetEqualRows(List<string> allTickets)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < allTickets.Count; i++)
        {
            for (int j = i + 1; j < allTickets.Count; j++)
            {
                if (allTickets[i].Substring(1) == allTickets[j].Substring(1))
                {
                    result.Add(allTickets[i]);
                    result.Add(allTickets[j]);
                    return result;
                }
            }
        }
        return null;
    }
}