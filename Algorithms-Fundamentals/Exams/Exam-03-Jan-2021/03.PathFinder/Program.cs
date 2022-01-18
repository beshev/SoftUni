using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.PathFinder
{
    internal class Program
    {
        private static HashSet<int>[] graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            var paths = int.Parse(Console.ReadLine());

            StringBuilder sb = CheckPaths(paths);

            Console.WriteLine(sb.ToString());
        }

        private static StringBuilder CheckPaths(int paths)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < paths; i++)
            {
                var currentPath = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = currentPath[0];

                var pathExist = true;

                for (int next = 1; next < currentPath.Length; next++)
                {
                    var nextNode = currentPath[next];

                    if (graph[node].Contains(nextNode) == false)
                    {
                        pathExist = false;
                        break;
                    }

                    node = nextNode;
                }

                sb.AppendLine(pathExist ? "yes" : "no");
            }

            return sb;
        }

        private static HashSet<int>[] ReadGraph(int n)
        {
            HashSet<int>[] newGraph = new HashSet<int>[n];

            for (int node = 0; node < newGraph.Length; node++)
            {
                newGraph[node] = new HashSet<int>();
            }

            for (int node = 0; node < n; node++)
            {
                var rowData = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(rowData))
                {
                    continue;
                }

                List<int> children = rowData
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (var child in children)
                {
                    newGraph[node].Add(child);
                }

            }

            return newGraph;
        }
    }
}
