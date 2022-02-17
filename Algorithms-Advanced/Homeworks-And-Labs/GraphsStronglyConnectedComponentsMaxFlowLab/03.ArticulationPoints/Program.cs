using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ArticulationPoints
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
            var lines = int.Parse(Console.ReadLine());

            visited = new bool[nodes];
            depths = new int[nodes];
            lowPoint = new int[nodes];
            points = new List<int>();
            graph = new List<int>[nodes];
            parents = new int[nodes];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
                parents[node] = -1;
            }


            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = line[0];

                for (int j = 1; j < line.Length; j++)
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

            Console.WriteLine($"Articulation points: {string.Join(", ", points)}");
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
    }
}
