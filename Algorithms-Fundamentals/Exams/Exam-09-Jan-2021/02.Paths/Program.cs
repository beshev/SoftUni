using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Paths
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
            }

            visited = new bool[nodes];

            for (int node = 0; node < nodes - 1; node++)
            {
                string rowData = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(rowData))
                {
                    continue;
                }

                var children = rowData
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                graph[node] = children;
            }

            for (int node = 0; node < graph.Length - 1; node++)
            {
                DFS(node);
            }

        }

        private static void DFS(int node)
        {
            visited[node] = true;

            if (node == graph.Length - 1)
            {
                PrintPath();
                return;
            }

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            visited[node] = false;
        }

        private static void PrintPath()
        {
            var path = new List<int>();

            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i])
                {
                    path.Add(i);
                }
            }

            Console.WriteLine(String.Join(' ', path));
        }
    }
}
