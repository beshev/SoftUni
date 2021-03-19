using System;

namespace _06.Valid_Person
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName,string lastName,int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{value}","The first name cannot be null or empty string!");
                }
                this.firstName = value;
            } }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{value}","The last name cannot be null or empty string!");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException($"{value}","Age must be in range [0 ... 120].");
                }
                this.age = value;
            }
        }
    }
}
