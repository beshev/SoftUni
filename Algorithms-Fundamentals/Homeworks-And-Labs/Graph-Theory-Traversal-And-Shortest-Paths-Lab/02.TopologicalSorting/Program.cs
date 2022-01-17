using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        //private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);


            try
            {

                foreach (var node in graph.Keys)
                {
                    var result = new Stack<string>();
                    TopSortDFS(node, result);

                    if (result.Count > 0)
                    {
                        Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");
                    }
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // dependencies = GetDependencies();
            // SourceRemoval();
        }

        private static void TopSortDFS(string node, Stack<string> result)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                TopSortDFS(child, result);
            }

            cycles.Remove(node);
            result.Push(node);
        }

        //private static void SourceRemoval()
        //{
        //    var sorted = new List<string>();

        //    while (dependencies.Count > 0)
        //    {
        //        var node = dependencies.FirstOrDefault(x => x.Value == 0);

        //        if (node.Key == null)
        //        {
        //            break;
        //        }

        //        foreach (var child in graph[node.Key])
        //        {
        //            dependencies[child]--;
        //        }

        //        sorted.Add(node.Key);
        //        dependencies.Remove(node.Key);
        //    }

        //    if (dependencies.Count > 0)
        //    {
        //        Console.WriteLine("Invalid topological sorting");
        //        return;
        //    }

        //    Console.WriteLine($"Topological sorting: {String.Join(", ", sorted)}");
        //}

        private static Dictionary<string, int> GetDependencies()
        {
            var result = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                var key = node.Key;
                var children = node.Value;

                if (!result.ContainsKey(key))
                {
                    result[key] = 0;
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 0;
                    }

                    result[child]++;
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var node = parts[0].Trim();
                List<string> children = new List<string>();

                if (parts.Length > 1)
                {
                    children = parts[1]
                    .Split(", ")
                    .Select(x => x.Trim())
                    .ToList();
                }

                graph.Add(node, children);
            }

            return graph;
        }
    }
}
