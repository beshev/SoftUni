using System;

using _09.ExplicitInterfaces.Models;
using _09.ExplicitInterfaces.Models.Contracts;
namespace _09.ExplicitInterfaces.Core
{
    class Engine
    {
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                string counrty = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Citizen person = new Citizen(name,counrty,age);

                Console.WriteLine(((IPerson)person).GetName());
                Console.WriteLine(((IResident)person).GetName());
            }
        }
    }
}
