using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._3._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalSkills = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Season end")
            {
                string[] command = input.Split().ToArray();
                if (command.Contains("->"))
                {
                    command = input.Split(" -> ").ToArray();
                    string name = command[0];
                    string posiotion = command[1];
                    int skill = int.Parse(command[2]);
                    if (result.ContainsKey(name))
                    {
                        if (result[name].ContainsKey(posiotion) == false)
                        {
                            result[name].Add(posiotion, skill);
                            totalSkills[name] += skill;
                        }
                        else if (result[name].ContainsKey(posiotion) && result[name][posiotion] < skill)
                        {
                            totalSkills[name] -= result[name][posiotion];
                            totalSkills[name] += skill;
                            result[name][posiotion] = skill;
                        }
                    }
                    else
                    {
                        result.Add(name, new Dictionary<string, int>());
                        result[name].Add(posiotion, skill);
                        totalSkills.Add(name, skill);
                    }
                }
                else
                {
                    command = input.Split(" vs ").ToArray();
                    string first = command[0];
                    string second = command[1];
                    if (result.ContainsKey(first) && result.ContainsKey(second))
                    {

                    }

                }
                input = Console.ReadLine();
            }

            foreach (var user in totalSkills.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{user.Key}: {user.Value} skills");
                Console.WriteLine(String.Join(Environment.NewLine,
                    result[user.Key].OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .Select(x => $"- {x.Key} <::> {x.Value}")));
            }
        }
    }
}
