using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonalInformation> listOfInformatio = new List<PersonalInformation>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] currnetPersonInfo = input.Split();
                PersonalInformation currentPerson = new PersonalInformation(currnetPersonInfo[0],
                    currnetPersonInfo[1], int.Parse(currnetPersonInfo[2]));
                listOfInformatio.Add(currentPerson);
                input = Console.ReadLine();
            }

            foreach (var person in listOfInformatio.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{person.FirstName} with ID: {person.PersonalId} is {person.Age} years old.");
            }
        }
    }

    public class PersonalInformation
    {
        public PersonalInformation(string firstName , string personalId , int age)
        {
            this.FirstName = firstName;
            this.PersonalId = personalId;
            this.Age = age;
        }
        public string FirstName { get; set; }
        public string PersonalId { get; set; }
        public int  Age { get; set; }
    }
}
