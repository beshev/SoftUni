using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BreakCycles
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();

            var result = RemoveCycles();

            Console.WriteLine($"Edges to remove: {result.Count}");
            result.ForEach(x => Console.WriteLine(x));
        }

        private static List<string> RemoveCycles()
        {
            var result = new List<string>();

            foreach (var node in graph.Keys.OrderBy(x => x))
            {
                visited.Clear();

                while (IsCyclicUtil(node) && graph[node].Count > 1)
                {
                    visited.Clear();

                    var removedEdge = graph[node].FirstOrDefault();

                    graph[node].Remove(removedEdge);
                    graph[removedEdge].Remove(node);
                    result.Add($"{node} - {removedEdge}");
                }
            }

            return result;
        }

        private static bool IsCyclicUtil(string node, string parent = "")
        {
            visited.Add(node);

            foreach (string child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    if (IsCyclicUtil(child, node))
                        return true;
                }
                else if (child != parent)
                    return true;
            }

            return false;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var newGraph = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var rowInfo = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                var node = rowInfo[0];
                var children = rowInfo[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .OrderBy(x => x)
                    .ToList();

                newGraph[node] = new List<string>(children);
            }

            return newGraph;
        }
    }
}
