using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }

        public class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public Person()
            {

            }
        }

        class Family
        {
            public List<Person> People;

            public Family()
            {
                this.People = new List<Person>();
            }

            public void AddMember(Person person)
            {
                People.Add(person);
            }

            public Person GetOldestMember()
            {
                People = People.OrderByDescending(x => x.Age).ToList();
                Person oldestMember = People[0];
                return oldestMember;
            }
        }
    }
}
