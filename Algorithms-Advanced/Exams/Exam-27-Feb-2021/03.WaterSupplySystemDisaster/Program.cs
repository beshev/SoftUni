using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WaterSupplySystemDisaster
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depths;
        private static int[] lowPoint;
        private static int[] parents;
        private static List<int> points;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var separetedParts = int.Parse(Console.ReadLine());

            visited = new bool[nodes + 1];
            depths = new int[nodes + 1];
            lowPoint = new int[nodes + 1];
            points = new List<int>();
            graph = new List<int>[nodes + 1];
            parents = new int[nodes + 1];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
                parents[node] = -1;
            }

            for (int node = 1; node < nodes; node++)
            {
                var line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    var child = line[j];

                    graph[node].Add(child);
                    graph[child].Add(node);
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, 1);
            }

            foreach (var point in points)
            {
                var count = GetCountAfterRemove(point);

                if (count == separetedParts)
                {
                    Console.WriteLine(point);
                    return;
                }
            }

            Console.WriteLine(0);
        }

        private static void DFS(int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowPoint[node] = depth;

            var children = 0;
            var isArticulation = false;

            foreach (var child in graph[node])
            {
                if (visited[child] == false)
                {
                    parents[child] = node;
                    DFS(child, depth + 1);
                    children++;

                    if (lowPoint[child] >= depth)
                    {
                        isArticulation = true;
                    }

                    lowPoint[node] = Math.Min(lowPoint[node], lowPoint[child]);
                }
                else if (parents[node] != child)
                {
                    lowPoint[node] = Math.Min(lowPoint[node], depths[child]);
                }
            }

            if ((parents[node] == -1 && children > 1) ||
                (parents[node] != -1 && isArticulation))
            {
                points.Add(node);
            }
        }

        private static int GetCountAfterRemove(int nodeToRemove)
        {
            var visitedNodes = new bool[graph.Length];
            var components = 0;

            var deletedNodes = new bool[graph.Length];
            deletedNodes[nodeToRemove] = true;

            for (int currentNode = 1; currentNode < graph.Length; currentNode++)
            {
                if (deletedNodes[currentNode])
                {
                    continue;
                }

                if (visitedNodes[currentNode] == false)
                {
                    ConnectedComponents(currentNode, visitedNodes, deletedNodes);
                    components++;
                }
            }

            return components;
        }

        private static void ConnectedComponents(int node, bool[] visitedNodes, bool[] deletedNodes)
        {
            if (visitedNodes[node] || deletedNodes[node])
            {
                return;
            }

            visitedNodes[node] = true;

            foreach (var child in graph[node])
            {
                ConnectedComponents(child, visitedNodes, deletedNodes);
            }
        }
    }
}
