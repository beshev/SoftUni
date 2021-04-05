using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person("Bat Misho",25);
            Console.WriteLine(newPerson.Name + " " + newPerson.Age);
            Person second = new Person();
            Console.WriteLine(second.Name + " " + second.Age);
            Person third = new Person(2);
            Console.WriteLine(third.Name + " " + third.Age);

        }
    }
}
