using System;
using System.Collections.Generic;
using System.IO;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                persons.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
                input = Console.ReadLine();
            }
            int n = int.Parse(Console.ReadLine());
            Person currentPerson = persons[n - 1];

            int matches = 0;
            int notMatches = 0;
            foreach (var person in persons)
            {
                if (currentPerson.CompareTo(person) == 0)
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }
            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {notMatches} {persons.Count}");
            }
        }
    }
}
