using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShortestPath
{
    internal class Program
    {
        private static HashSet<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());



            graph = new HashSet<int>[n + 1];
            visited = new bool[graph.Length];

            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            for (int i = 1; i < graph.Length; i++)
            {
                graph[i] = new HashSet<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var nodeInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = graph[nodeInfo[0]];
                var child = nodeInfo[1];

                node.Add(child);
            }

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            FindPath(startNode, endNode);
        }

        private static Stack<int> GetPath(int destination)
        {
            Stack<int> result = new Stack<int>();
            result.Push(destination);

            var node = parents[destination];

            while (node != -1)
            {
                result.Push(node);
                node = parents[node];
            }

            return result;
        }

        private static void FindPath(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(String.Join(' ', path));
                    return;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}
