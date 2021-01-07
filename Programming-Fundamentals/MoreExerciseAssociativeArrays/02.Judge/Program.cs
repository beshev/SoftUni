using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalPoints = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] currentStudentInfo = input.Split(" -> ",
                    StringSplitOptions.RemoveEmptyEntries);
                string name = currentStudentInfo[0];
                string contest = currentStudentInfo[1];
                int point = int.Parse(currentStudentInfo[2]);
                if (result.ContainsKey(contest))
                {
                    if (result[contest].Any(x => x.Key.Contains(name)) && result[contest][name] < point)
                    {
                        totalPoints[name] -= result[contest][name];
                        totalPoints[name] += point;
                        result[contest][name] = point;
                    }
                    if (result[contest].ContainsKey(name) == false)
                    {
                        result[contest].Add(name, point);
                        AddPointsToStudents(totalPoints, name, point);
                    }
                }
                else
                {
                    result.Add(contest, new Dictionary<string, int>());
                    result[contest].Add(name, point);
                    AddPointsToStudents(totalPoints, name, point);
                }
                input = Console.ReadLine();
            }

            foreach (var contest in result)
            {
                int lines = 1;
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                Console.WriteLine(string.Join(Environment.NewLine,
                    contest.Value.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .Select(x => $"{lines++}. {x.Key} <::> {x.Value}")));
            }
            int position = 1;
            Console.WriteLine("Individual standings:");
            Console.WriteLine(String.Join(Environment.NewLine,
                totalPoints.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{position++}. {x.Key} -> {x.Value}")));
        }

        static void AddPointsToStudents(Dictionary<string, int> students, string name, int points)
        {
            if (students.ContainsKey(name))
            {
                students[name] += points;
            }
            else
            {
                students.Add(name, points);
            }
        }
    }
}
