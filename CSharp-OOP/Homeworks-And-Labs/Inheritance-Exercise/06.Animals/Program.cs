using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            Animal test = new Animal("Bug", 2,"Male");
            test.ProduceSound();
            string animal = string.Empty;
            while ((animal = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];
                bool isValidInput = (age > 0) && (gender == "Male" || gender == "Female") && (name != string.Empty);
                bool isValidClass = animal == "Cat" || animal == "Dog" || animal == "Frog" 
                    || animal == "Kitten" || animal == "Tomcat";
                if (isValidInput && isValidClass)
                {
                    AddAnimal(animals, animal, name, age, gender);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            foreach (var animal1 in animals)
            {
                Console.WriteLine(animal1.Type());
                Console.WriteLine(animal1.ToString());
                Console.WriteLine(animal1.ProduceSound());
            }
        }

        private static void AddAnimal(List<Animal> animals, string animal, string name, int age, string gender)
        {
            if (animal == "Dog")
            {
                animals.Add(new Dog(name, age, gender));
            }
            else if (animal == "Cat")
            {
                animals.Add(new Cat(name, age, gender));
            }
            else if (animal == "Frog")
            {
                animals.Add(new Frog(name, age, gender));
            }
            else if (animal == "Kitten")
            {
                animals.Add(new Kitten(name, age));
            }
            else if (animal == "Tomcat")
            {
                animals.Add(new Tomcat(name, age));
            }
        }
    }
}
