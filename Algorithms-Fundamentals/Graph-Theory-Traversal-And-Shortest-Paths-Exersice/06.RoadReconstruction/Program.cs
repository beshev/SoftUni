using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.RoadReconstruction
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static bool[] deletedEdge;
        private static HashSet<string> checkedEdges;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new bool[graph.Length];
            deletedEdge = new bool[graph.Length];
            checkedEdges = new HashSet<string>();

            Console.WriteLine(FindImportantStreets());
        }

        private static string FindImportantStreets()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Important streets:");

            for (int node = 0; node < graph.Length; node++)
            {

                for (int child = 0; child < graph[node].Count; child++)
                {
                    if (checkedEdges.Contains($"{node}{graph[node][child]}")
                        || checkedEdges.Contains($"{graph[node][child]}{node}"))
                    {
                        continue;
                    }
                    checkedEdges.Add($"{node}{graph[node][child]}");

                    ResetVisited();

                    deletedEdge[graph[node][child]] = true;
                    deletedEdge[node] = true;

                    if (visited[node])
                    {
                        continue;
                    }

                    TraversAllStreets(node);

                    if (!visited.All(x => x))
                    {
                        sb.AppendLine($"{node} {graph[node][child]}");
                    }

                    deletedEdge[node] = false;
                    deletedEdge[graph[node][child]] = false;
                }
            }

            return sb.ToString().Trim();
        }

        private static void ResetVisited()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

        private static void TraverseAllStreets(int node, int parent = 0)
        {
            if (node != parent && deletedEdge[node] && deletedEdge[parent])
            {
                return;
            }

            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    TraversAllStreets(child, node);
                }
            }
        }

        private static List<int>[] ReadGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var newGraph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                newGraph[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var parts = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(parts[0]);
                var child = int.Parse(parts[1]);

                newGraph[node].Add(child);
                newGraph[child].Add(node);
            }

            return newGraph;
        }
    }
}
