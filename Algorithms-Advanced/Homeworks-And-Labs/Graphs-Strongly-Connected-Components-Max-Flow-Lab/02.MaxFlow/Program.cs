using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MaxFlow
{
    internal class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var graph = new int[n][];

            for (int row = 0; row < graph.GetLength(0); row++)
            {
                var rowData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                graph[row] = rowData;
            }

            var source = int.Parse(Console.ReadLine());
            var target = int.Parse(Console.ReadLine());

            var parents = new int[n];
            Array.Fill(parents, -1);

            var maxFlow = 0;

            while (BFS(graph, source, target, parents))
            {
                var minFlow = int.MaxValue;

                var to = target;
                var from = parents[to];

                while (to != -1 && from != -1)
                {
                    minFlow = Math.Min(minFlow, graph[from][to]);

                    to = parents[to];
                    from = parents[to];
                }

                maxFlow += minFlow;

                to = target;
                from = parents[to];

                while (to != -1 && from != -1)
                {
                    graph[from][to] -= minFlow;

                    to = parents[to];
                    from = parents[to];
                }
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static bool BFS(int[][] graph, int source, int target, int[] parents)
        {
            var visited = new bool[graph.Length];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph[node].Length; child++)
                {
                    if (visited[child] == false && graph[node][child] > 0)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[target];
        }
    }
}
