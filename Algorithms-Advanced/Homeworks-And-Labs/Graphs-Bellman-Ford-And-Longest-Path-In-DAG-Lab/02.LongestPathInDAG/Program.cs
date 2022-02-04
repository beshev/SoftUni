using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.LongestPathInDAG
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes + 1];

            for (int node = 1; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                graph[edgeData[0]].Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            var sorted = TopologicalSorting();

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);

            distance[start] = 0;

            while(sorted.Count > 0)
            {
                var node = sorted.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;
                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node, result, visited);
            }

            return result;
        }

        private static void DFS(int node, Stack<int> result, HashSet<int> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var edge in graph[node])
            {
                DFS(edge.To, result, visited);
            }

            result.Push(node);
        }
    }
}
