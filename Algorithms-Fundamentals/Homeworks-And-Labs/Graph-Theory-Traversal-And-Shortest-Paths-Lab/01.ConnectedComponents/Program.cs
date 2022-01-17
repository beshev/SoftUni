using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var components = new List<int>();
                DFS(node, components);

                Console.WriteLine($"Connected component: {String.Join(' ', components)}");
            }
        }

        private static void DFS(int node, List<int> compenents)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, compenents);
            }

            compenents.Add(node);
        }

        private static List<int>[] ReadGraph(int n)
        {
            var result = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                var children = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                result[node] = children;
            }

            return result;
        }
    }
}
