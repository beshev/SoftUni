using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredictParty
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] cmdArg = command.Split(' '
                    , StringSplitOptions.RemoveEmptyEntries);
                Predicate<string> predicate = GetPredicate(cmdArg[2], cmdArg[1]);
                if (cmdArg[0] == "Remove")
                {
                    names.RemoveAll(predicate);
                }
                else if (cmdArg[0] == "Double")
                {
                    var matches = names.FindAll(predicate);
                    if (matches.Count > 0)
                    {
                        int index = names.FindIndex(predicate);
                        names.InsertRange(index, matches);
                    }
                }
                command = Console.ReadLine();
            }
            Action<List<string>> printer = Printer();
            printer(names);
        }

        static Predicate<string> GetPredicate(string criteria, string commandType)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return name => name.StartsWith(criteria);
                case "EndsWith":
                    return name => name.EndsWith(criteria);
                case "Length":
                    return name => name.Length == int.Parse(criteria);
                default:
                    throw new ArgumentException("Invalid Command" + commandType);
            }
        }

        static Action<List<string>> Printer()
        {
            return persons =>
            {
                if (persons.Count > 0)
                {
                    Console.Write(string.Join(", ", persons));
                    Console.Write($" are going to the party!");

                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
            };
        }
    }
}