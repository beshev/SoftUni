using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            foreach (var person in people.Where(p => p.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
