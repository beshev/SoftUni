using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var warDrob = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(new string[] {" -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string currentColor = cmd[0];
                if (warDrob.ContainsKey(currentColor) == false)
                {
                    warDrob.Add(currentColor, new Dictionary<string, int>());
                }
                for (int j = 1; j < cmd.Length; j++)
                {
                    string currentClothing = cmd[j];
                    if (warDrob[currentColor].ContainsKey(currentClothing) == false)
                    {
                        warDrob[currentColor].Add(currentClothing, 0);
                    }
                    warDrob[currentColor][currentClothing]++;
                }
            }
            string[] clothingToFind = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string color = clothingToFind[0];
            string clothing = clothingToFind[1];
            foreach (var colors in warDrob)
            {
                Console.WriteLine($"{colors.Key} clothes:");
                foreach (var clothes in colors.Value)
                {
                    Console.Write($"* {clothes.Key} - {clothes.Value}");
                    if (colors.Key == color && clothes.Key == clothing)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
