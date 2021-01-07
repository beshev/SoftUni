using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, List<Dwarf>> alldwarfs = new Dictionary<string, List<Dwarf>>();
            List<Dwarf> result = new List<Dwarf>();
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                List<string> splitInput = input.Split(new[] { ' ', '<', '>', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = splitInput[0];
                string colour = splitInput[1];
                int physics = int.Parse(splitInput[2]);

                if (!alldwarfs.ContainsKey(colour))
                {
                    alldwarfs[colour] = new List<Dwarf>();
                }
                if (!alldwarfs[colour].Any(x => x.Name == name))
                {
                    Dwarf dwarf = new Dwarf();
                    dwarf.Name = name;
                    dwarf.Physics = physics;
                    dwarf.Colour = colour;
                    alldwarfs[colour].Add(dwarf);
                    result.Add(dwarf);
                }
                else
                {
                    var tempDwarf = alldwarfs[colour].FirstOrDefault(x => x.Name == name);
                    tempDwarf.Physics = Math.Max(tempDwarf.Physics, physics);
                }
            }
            result = result.OrderByDescending(x => x.Physics).ThenByDescending(a => alldwarfs[a.Colour].Count).ToList();
            foreach (var dwarf in result)
            {

                Console.WriteLine($"({dwarf.Colour}) {dwarf.Name} <-> {dwarf.Physics}");

            }
        }
    }
    class Dwarf
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Physics { get; set; }
    }
}