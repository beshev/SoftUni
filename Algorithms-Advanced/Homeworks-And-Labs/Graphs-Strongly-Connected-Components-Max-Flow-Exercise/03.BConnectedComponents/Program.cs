using System;
using System.Collections.Generic;
using System.Linq;

namespace BConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depths;
        private static int[] lowpoint;
        private static int[] parents;
        private static List<int> points;
        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            components = new();
            points = new();
            stack = new();

            visited = new bool[nodes];
            depths = new int[nodes];
            lowpoint = new int[nodes];
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = line[0];
                var child = line[1];

                graph[node].Add(child);
                graph[child].Add(node);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node] == false)
                {
                    FindArticulationPoints(node, 1);

                    var component = new HashSet<int>();


                    while (stack.Count > 1)
                    {
                        var stackChild = stack.Pop();
                        var stackNode = stack.Pop();

                        component.Add(stackNode);
                        component.Add(stackChild);
                    }

                    components.Add(component);

                }
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoints(int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowpoint[node] = depth;

            var childCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parents[child] = node;
                    childCount += 1;

                    FindArticulationPoints(child, depth + 1);

                    if ((parents[node] == -1 && childCount > 1) ||
                        (parents[node] != -1 && lowpoint[child] >= depth))
                    {
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node &&
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parents[node] != child &&
                    depths[child] < lowpoint[node])
                {
                    lowpoint[node] = depths[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }
    }
}
