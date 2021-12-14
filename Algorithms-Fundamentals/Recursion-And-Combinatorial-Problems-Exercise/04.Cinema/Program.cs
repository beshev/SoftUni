using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cinema
{
    internal class Program
    {
        private static string[] usedPlaces;
        private static List<string> names;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            usedPlaces = new string[names.Count];

            string nameNumberAsString;

            while ((nameNumberAsString = Console.ReadLine()) != "generate")
            {
                var nameNumberInfo = nameNumberAsString.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                var name = nameNumberInfo[0];
                var number = int.Parse(nameNumberInfo[1]);

                usedPlaces[number - 1] = name;
                names.Remove(name);
            }

            GeneratePlaces();
        }


        static void GeneratePlaces(int index = 0)
        {
            if (index >= names.Count)
            {
                Console.WriteLine(String.Join(' ', usedPlaces));
                return;
            }

            for (int i = 0; i < usedPlaces.Length; i++)
            {
                if (usedPlaces[i] == null)
                {
                    usedPlaces[i] = names[index];
                    GeneratePlaces(index + 1);
                    usedPlaces[i] = null;
                }
            }
        }
    }
}
