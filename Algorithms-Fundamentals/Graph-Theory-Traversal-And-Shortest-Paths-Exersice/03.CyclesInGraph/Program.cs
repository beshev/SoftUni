using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CyclesInGraph
{
    internal class Program
    {
        private static Dictionary<string, string> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            bool hasCycles = true;

            foreach (var node in graph.Keys)
            {
                hasCycles = CheckForCycles(node);

                if (hasCycles)
                {
                    break;
                }
            }

            Console.WriteLine("Acyclic: {0}", hasCycles ? "No" : "Yes");
        }

        private static bool CheckForCycles(string node)
        {
            if (cycles.Contains(node))
            {
                return true;
            }

            if (visited.Contains(node) || graph.ContainsKey(node) == false)
            {
                return false;
            }

            visited.Add(node);
            cycles.Add(node);

            bool isAcyclic = CheckForCycles(graph[node]);

            cycles.Remove(node);

            return isAcyclic;
        }

        private static Dictionary<string, string> ReadGraph()
        {
            var graph = new Dictionary<string, string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputInfo = input.Split('-', StringSplitOptions.RemoveEmptyEntries);

                graph[inputInfo[0]] = inputInfo[1];
            }

            return graph;
        }
    }
}
