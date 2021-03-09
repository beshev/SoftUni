using System;
using System.Collections.Generic;

using _04.BorderControl.Models;
using _04.BorderControl.Models.Contracts;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            List<IId> identity = new List<IId>();

            AddCitizensAndRobots(identity);

            string fakeIdNumbers = Console.ReadLine();
            PrintAllFakeIds(identity, fakeIdNumbers);
        }

        private static void AddCitizensAndRobots(List<IId> identity)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string nameOrModel = tokens[0];
                if (tokens.Length == 3)
                {
                    identity.Add(new Citizen(nameOrModel, int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    identity.Add(new Robot(nameOrModel, tokens[1]));
                }
            }
        }

        private static void PrintAllFakeIds(List<IId> identity,string fakeIdNumbers)
        {
            foreach (var item in identity)
            {
                if (item.Id.EndsWith(fakeIdNumbers))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
