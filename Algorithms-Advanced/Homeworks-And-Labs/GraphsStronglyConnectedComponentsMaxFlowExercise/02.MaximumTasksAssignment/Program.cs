using System;
using System.Collections.Generic;

namespace _02.MaximumTasksAssignment
{
    internal class Program
    {
        static void Main()
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            var nodes = peopleCount + tasks + 2;

            var graph = new int[nodes, nodes];

            for (int i = 1; i < peopleCount + 1; i++)
            {
                graph[0, i] = 1;
            }

            for (int i = graph.GetLength(0) - peopleCount - 1; i < graph.GetLength(0) - 1; i++)
            {
                graph[i, graph.GetLength(0) - 1] = 1;
            }

            for (int node = 1; node < tasks + 1; node++)
            {
                var row = Console.ReadLine();

                for (int child = 0; child < row.Length; child++)
                {
                    if (row[child] == 'Y')
                    {
                        graph[node, tasks + child + 1] = 1;
                    }
                }
            }

            var source = 0;
            var target = nodes - 1;

            var parents = new int[nodes];
            Array.Fill(parents, -1);

            while (BFS(graph, source, target, parents))
            {
                var node = target;

                while (node != source)
                {
                    var parent = parents[node];

                    graph[parent, node] = 0;
                    graph[node, parent] = 1;

                    node = parent;
                }
            }

            for (int person = 1; person <= peopleCount; person++)
            {
                for (int task = peopleCount + 1; task <= peopleCount + tasks; task++)
                {
                    if (graph[task, person] > 0)
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - peopleCount}");
                    }
                }
            }
        }

        private static bool BFS(int[,] graph, int source, int target, int[] parents)
        {
            var visited = new bool[graph.GetLength(0) + 1];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (visited[child] == false && graph[node, child] > 0)
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
