using System;
using System.Collections.Generic;
using System.IO;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hash = new HashSet<Person>();
            SortedSet<Person> sordet = new SortedSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(tokens[0], int.Parse(tokens[1]));
                hash.Add(currentPerson);
                sordet.Add(currentPerson);
            }
            Console.WriteLine(hash.Count);
            Console.WriteLine(sordet.Count);

        }

    }
}

