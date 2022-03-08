using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BlackFriday
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }


    internal class Program
    {
        private static int[] parent;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            var edgesCount = int.Parse(Console.ReadLine());

            var edges = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                edges.Add(new Edge
                {
                    First = edgeArgs[0],
                    Second = edgeArgs[1],
                    Weight = edgeArgs[2]
                });
            }

            parent = new int[nodes];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var sortedEdges = edges.OrderBy(e => e.Weight);

            var totalWeight = 0;

            foreach (var edge in sortedEdges)
            {
                var rootOne = FindRoot(edge.First);
                var rootTwo = FindRoot(edge.Second);

                if (rootOne == rootTwo)
                {
                    continue;
                }

                totalWeight += edge.Weight;
                parent[rootOne] = rootTwo;
            }

            Console.WriteLine(totalWeight);
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
