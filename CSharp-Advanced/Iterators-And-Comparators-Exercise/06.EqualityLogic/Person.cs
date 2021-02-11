using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Person other)
            {
                return this.age == other.age && this.name == other.name;
            }
            return false;
        }


        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }
            return result;
        }
    }
}
