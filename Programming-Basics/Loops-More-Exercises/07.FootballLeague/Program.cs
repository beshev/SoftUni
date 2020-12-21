using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int numFans = int.Parse(Console.ReadLine());
            double sectorA = 0;
            double sectorB = 0;
            double sectorV = 0;
            double sectorG = 0;


            // Find num fans for each sector
            for (int i = 0; i < numFans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A':
                        sectorA++;
                        break;
                    case 'B':
                        sectorB++;
                        break;
                    case 'V':
                        sectorV++;
                        break;
                    case 'G':
                        sectorG++;
                        break;
                }

            }
            // Percentage of fans for each sector
            sectorA = sectorA / numFans * 100;
            sectorB = sectorB / numFans * 100;
            sectorV = sectorV / numFans * 100;
            sectorG = sectorG / numFans * 100;
            // Percentage for all fans in stadium
            double percentageForAllFans = ((numFans * 1.0) / stadiumCapacity) * 100;
            Console.WriteLine($"{sectorA:f2}%");
            Console.WriteLine($"{sectorB:f2}%");
            Console.WriteLine($"{sectorV:f2}%");
            Console.WriteLine($"{sectorG:f2}%");
            Console.WriteLine($"{percentageForAllFans:f2}%");
            
        }
    }
}
