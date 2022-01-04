using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.DistanceBetweenVertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static Dictionary<int, int> parent;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            visited = new HashSet<int>();

            parent = new Dictionary<int, int>();

            var sb = new StringBuilder();

            for (int i = 0; i < p; i++)
            {
                var pathInfo = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var startNode = pathInfo[0];
                var destination = pathInfo[1];

                sb.AppendLine(FindPath(startNode, destination));
            }

            Console.WriteLine(sb.ToString());
        }

        private static string FindPath(int startNode, int destination)
        {
            var sb = new StringBuilder();
            visited.Clear();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);

            visited.Add(startNode);

            var hasPath = false;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    hasPath = true;
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        parent[child] = node;
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            int pathCount = -1;

            if (hasPath)
            {
                pathCount = GetPathCount(startNode, destination);
            }

            sb.AppendLine($"{{{startNode}, {destination}}} -> {pathCount}");

            return sb.ToString().Trim();

        }

        private static int GetPathCount(int startNode, int destination)
        {
            var node = parent[destination];

            var count = 1;

            while (node != startNode)
            {
                node = parent[node];
                count++;
            }

            return count;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var pair = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var node = int.Parse(pair[0]);
                var children = pair.Length > 1 ? pair[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList() : new List<int>();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<int>();
                }

                graph[node].AddRange(children);
            }

            return graph;
        }
    }
}
