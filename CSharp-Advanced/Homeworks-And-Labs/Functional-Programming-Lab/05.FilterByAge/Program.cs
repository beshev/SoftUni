using System;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                persons[i] = new Person() { Name = input[0], Age = int.Parse(input[1]) };
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<Person, bool> conditionDelegate = Condition(condition, age);
            Action<Person> printDelegate = Printer(format);
            foreach (var person in persons)
            {
                if (conditionDelegate(person))
                {
                    printDelegate(person);
                }
            }
        }

        static Action<Person> Printer(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine(p.Name);
            }
            else if (format == "age")
            {
                return p => Console.WriteLine(p.Age);
            }
            else if (format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            return null;
        }

        static Func<Person, bool> Condition(string condition, int age)
        {
            if (condition == "younger")
            {
                return p => p.Age < age;
            }
            else if (condition == "older")
            {
                return p => p.Age >= age;
            }
            return null;
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

    }
}
