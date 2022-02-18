using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ElectricalSubstationNetwork
{
    internal class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            var graph = new List<int>[n];
            var reversedGraph = new List<int>[n];
            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();
                reversedGraph[node] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                var row = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var node = row[0];

                for (int j = 1; j < row.Count; j++)
                {
                    var child = row[j];

                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            var visited = new bool[n];
            var sorted = new Stack<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[n];

            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                var components = new Stack<int>();
                DFS(node, reversedGraph, visited, components);

                Console.WriteLine(string.Join(", ", components));

            }
        }

        private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, graph, visited, result);
            }

            result.Push(node);
        }
    }
}
