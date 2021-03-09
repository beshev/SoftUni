using System;
using System.Collections.Generic;
using System.Linq;
using _05.BirthdayCelebrations;
using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Contracts;


namespace _05.BirthdayCelebrations
{
    public class Engine
    {
        public void Run()
        {
            List<IBirthdatefiable> birthdates = new List<IBirthdatefiable>();
            AddCitizensAndPets(birthdates);

            string birthDate = Console.ReadLine();
            birthdates
                .Where(d => d.Birthdate.EndsWith(birthDate))
                .Select(d => d.Birthdate)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static void AddCitizensAndPets(List<IBirthdatefiable> birthdates)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                if (type == "Citizen")
                {
                    birthdates.Add(new Citizen(tokens[1],int.Parse(tokens[2]),tokens[3],tokens[4]));
                }
                else if (type == "Pet")
                {
                    birthdates.Add(new Pet(tokens[1], tokens[2]));
                }
            }
        }
    }
}
