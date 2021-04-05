using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    class Person : IComparable<Person>
    {
        private string name;

        private int age;

        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            int nameCompare = this.name.CompareTo(other.name);
            int ageCompare = this.age.CompareTo(other.age);
            int townCompare = this.town.CompareTo(other.town);
            if ((nameCompare == 0) && (ageCompare == 0) && (townCompare == 0))
            {
                return 0;
            }
            return -1;
        }
    }
}
