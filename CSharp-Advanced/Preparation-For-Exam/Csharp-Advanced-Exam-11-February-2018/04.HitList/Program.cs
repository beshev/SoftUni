using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, Dictionary<string, string>>();
            string input = Console.ReadLine();
            while (input != "end transmissions")
            {
                string[] tokens = input.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (result.ContainsKey(tokens[0]) == false)
                {
                    result.Add(tokens[0], new Dictionary<string, string>());
                }
                for (int i = 1; i < tokens.Length; i++)
                {
                    string[] arg = tokens[i].Split(':', StringSplitOptions.RemoveEmptyEntries);
                    string key = arg[0];
                    string value = arg[1];
                    if (result[tokens[0]].ContainsKey(key) == false)
                    {
                        result[tokens[0]].Add(key, string.Empty);
                    }
                    result[tokens[0]][key] = value;
                }
                input = Console.ReadLine();
            }
            string toKill = Console.ReadLine().Substring(5);
            int indexInfo = 0;
            Console.WriteLine($"Info on {toKill}:");
            foreach (var keyValue in result[toKill].OrderBy(k => k.Key))
            {
                Console.WriteLine($"---{keyValue.Key}: {keyValue.Value}");
                indexInfo += (keyValue.Key.Length + keyValue.Value.Length);
            }
            Console.WriteLine($"Info index: {indexInfo}");
            if (indexInfo >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - indexInfo} more info.");
            }
        }
    }
}
