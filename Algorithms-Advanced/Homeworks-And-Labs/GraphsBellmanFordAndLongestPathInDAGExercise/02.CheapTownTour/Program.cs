namespace _02.CheapTownTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public double Weight { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            var edges = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                edges.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2],
                });
            }


            var parent = new int[nodesCount];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var sortedEges = edges.OrderBy(e => e.Weight).ToArray();

            var sum = 0d;

            foreach (var edge in sortedEges)
            {
                var firstRoot = FindRoot(edge.First, parent);
                var secondRoot = FindRoot(edge.Second, parent);

                if (firstRoot == secondRoot)
                {
                    continue;
                }

                parent[firstRoot] = secondRoot;

                sum += edge.Weight;
            }

            Console.WriteLine($"Total cost: {sum}");

        }

        private static int FindRoot(int node, int[] parent)
        {
            while (parent[node] != node)
            {
                node = parent[node];
            }

            return node;
        }
    }
}
