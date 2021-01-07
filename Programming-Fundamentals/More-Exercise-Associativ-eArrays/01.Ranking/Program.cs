using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] command = input.Split(':').ToArray();
                contests.Add(command[0], command[1]);
                input = Console.ReadLine();
            }
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] command = input.Split("=>").ToArray();
                string contest = command[0];
                string pass = command[1];
                string name = command[2];
                int points = int.Parse(command[3]);
                if (contests.ContainsKey(contest) && contests.ContainsValue(pass))
                {
                    if (result.ContainsKey(name))
                    {
                        if (result[name].ContainsKey(contest) == false)
                        {
                            result[name].Add(contest, points);
                        }
                        else
                        {
                            if (result[name].Where(x => x.Key.Contains(contest)).Any(x => x.Value < points))
                            {
                                result[name][contest] = points;
                            }
                        }
                    }
                    else
                    {
                        result.Add(name, new Dictionary<string, int>());
                        result[name].Add(contest, points);
                    }
                }
                input = Console.ReadLine();
            }
            List<int> list = new List<int>();
            int bestSum = 0;
            foreach (var item in result.Select(x => x.Value.Values.Sum()))
            {
                list.Add(item);
            }
            list.Sort();
            bestSum = list.Last();
            foreach (var item in result.Where(x => x.Value.Values.Sum() == bestSum))
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {bestSum} points.");
                break;
            }
            Console.WriteLine("Ranking: ");
            foreach (var student in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");
                Console.WriteLine(String.Join(Environment.NewLine,
                    student.Value.OrderByDescending(x => x.Value).Select(x => $"#  {x.Key} -> {x.Value}")));
            }
        }
    }

    public class User
    {
        public int Points { get; set; }

        public string Contest { get; set; }

        public User(string contest, int points)
        {
            this.Points = points;
            this.Contest = contest;
        }
    }
}
