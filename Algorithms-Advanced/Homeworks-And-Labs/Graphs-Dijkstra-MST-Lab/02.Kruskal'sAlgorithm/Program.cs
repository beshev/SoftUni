namespace _02.Kruskal_sAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static int[] parent;
        private static List<Edge> edges;

        static void Main()
        {
            var edgesCount = int.Parse(Console.ReadLine());

            edges = new List<Edge>();   

            var maxNode = -1;

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArg = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArg[0];
                var secondNode = edgeArg[1];

                edges.Add(new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeArg[2],
                });

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }

                if (secondNode > maxNode)
                {
                    maxNode = secondNode;
                }
            }

            parent = new int[maxNode + 1];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var sortedEdges = edges.OrderBy(e => e.Weight);

            foreach (var edge in sortedEdges)
            {
                var rootOne = FindRoot(edge.First);
                var rootTwo = FindRoot(edge.Second);

                if (rootOne == rootTwo)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");
                parent[rootOne] = rootTwo;
            }
        }

        private static int FindRoot(int startNode)
        {
            while (startNode != parent[startNode])
            {
                startNode = parent[startNode];
            }

            return startNode;
        }
    }
}
