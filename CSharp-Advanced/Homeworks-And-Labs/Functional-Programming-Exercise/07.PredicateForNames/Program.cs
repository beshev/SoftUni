using System;
using System.IO;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            Action<string[]> printerAndFilter = Printer(Filter(nameLength));
            printerAndFilter(names);
        }

        static Action<string[]> Printer(Func<string, bool> filter)
        {
            return names =>
            {
                foreach (var name in names)
                {
                    if (filter(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };
        }

        static Func<string, bool> Filter(int nameLength)
        {
            return x => x.Length <= nameLength;
        }
    }
}
