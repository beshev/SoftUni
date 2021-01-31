using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            names.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
