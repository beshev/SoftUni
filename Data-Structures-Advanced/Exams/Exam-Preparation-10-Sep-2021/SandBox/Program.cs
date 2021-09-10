using System;
using System.Collections;
using System.Collections.Generic;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();

            var persont = new Person() { Name = "Gogo", Id = 1, Age = 2 };

            hashtable.Add(persont.Id, persont);

            Console.WriteLine((hashtable[persont.Id] as Person).Name);
        }
    }


    class Person : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Person;

            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;

            return this.Id == other.Id;
        }
    }
}
