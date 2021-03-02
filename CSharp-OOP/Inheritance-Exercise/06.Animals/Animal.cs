using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }

        public virtual string ProduceSound() { throw new NullReferenceException("No Animal");}

        public string Type()
        {
            return this.GetType().Name;
        }
    }
}
