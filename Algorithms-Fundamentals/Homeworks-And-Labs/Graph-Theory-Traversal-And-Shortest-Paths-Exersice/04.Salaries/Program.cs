using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Salaries
{
    internal class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> nodeWithSalary;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            nodeWithSalary = new Dictionary<int, int>();

            Console.WriteLine(CalcSalaries());
        }

        private static int CalcSalaries()
        {
            int salaries = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                salaries += GetSalary(node);
            }

            return salaries;
        }

        private static int GetSalary(int node)
        {
            if (nodeWithSalary.ContainsKey(node))
            {
                return nodeWithSalary[node];
            }

            if (graph[node].Count == 0)
            {
                nodeWithSalary[node] = 1;
                return 1;
            }

            int salary = 0;

            for (int child = 0; child < graph[node].Count; child++)
            {
                salary += GetSalary(graph[node][child]);
            }

            nodeWithSalary[node] = salary;

            return salary;
        }

        private static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());

            var newGraph = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                var currentRow = Console.ReadLine();
                newGraph[node] = new List<int>();

                for (int child = 0; child < currentRow.Length; child++)
                {
                    if (currentRow[child] == 'Y')
                    {
                        newGraph[node].Add(child);
                    }
                }

            }

            return newGraph;
        }
    }
}
