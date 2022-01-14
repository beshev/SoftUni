using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheStoryTelling
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static Stack<string> stack;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            stack = new Stack<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var parts = input.Split("->", StringSplitOptions.RemoveEmptyEntries);

                var parent = parts[0].Trim();
                var children = new List<string>();

                if (parts.Length > 1)
                {
                    children = parts[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                }

                graph[parent] = children;
            }

            foreach (var key in graph.Keys)
            {
                DFS(key);
            }

            Console.WriteLine(String.Join(' ', stack));
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            stack.Push(node);
        }
    }
}
