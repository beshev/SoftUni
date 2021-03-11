using System;

using _09.ExplicitInterfaces.Models.Contracts;

namespace _09.ExplicitInterfaces.Models
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
