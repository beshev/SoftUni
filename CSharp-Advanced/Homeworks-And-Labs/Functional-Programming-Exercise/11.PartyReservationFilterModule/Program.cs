using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] cmdArg = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArg[0];
                string filter = $"{cmdArg[1]}-{cmdArg[2]}";
                if (type == "Add filter")
                {
                    filters.Add(filter);
                }
                else if (type == "Remove filter")
                {
                    filters.Remove(filter);
                }
                input = Console.ReadLine();
            }
            foreach (var filter in filters)
            {
                string[] currentFilter = filter.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string commandType = currentFilter[0];
                string arg = currentFilter[1];
                names.RemoveAll(new Predicate<string>(GetPredicate(commandType,arg)));
            }
            Console.WriteLine(string.Join(' ',names));
        }

        static Predicate<string> GetPredicate(string commandType, string arg)
        {
            return name =>
            {
                switch (commandType)
                {
                    case "Starts with":
                        return name.StartsWith(arg);
                    case "Ends with":
                        return name.EndsWith(arg);
                    case "Length":
                        return name.Length == int.Parse(arg);
                    case "Contains":
                        return name.Contains(arg);
                    default:
                        throw new ArgumentException($"Invalid Commnad -> {commandType}");
                }
            };
        }
    }
}
