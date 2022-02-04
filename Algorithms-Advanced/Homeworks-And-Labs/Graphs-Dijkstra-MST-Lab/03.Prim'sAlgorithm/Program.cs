namespace _03.Prim_sAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> treeNodes;

        static void Main()
        {
            graph = new Dictionary<int, List<Edge>>();
            treeNodes = new HashSet<int>();

            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgesArgs = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgesArgs[0];
                var secondNode = edgesArgs[1];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgesArgs[2],
                };

                if (graph.ContainsKey(firstNode) == false)
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (graph.ContainsKey(secondNode) == false)
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            foreach (var node in graph.Keys)
            {
                if (treeNodes.Contains(node) == false)
                {
                    Prim(node);
                }
            }
        }

        private static void Prim(int startNode)
        {
            treeNodes.Add(startNode);

            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            bag.AddMany(graph[startNode]);

            while (bag.Count > 0)
            {
                var smallestEdge = bag.RemoveFirst();

                var firstNode = smallestEdge.First;
                var secondNode = smallestEdge.Second;

                var nonTreeNode = -1;

                if (treeNodes.Contains(firstNode)
                    && treeNodes.Contains(secondNode) == false)
                {
                    nonTreeNode = secondNode;
                }

                if (treeNodes.Contains(secondNode)
                   && treeNodes.Contains(firstNode) == false)
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                treeNodes.Add(nonTreeNode);
                bag.AddMany(graph[nonTreeNode]);

                Console.WriteLine($"{firstNode} - {secondNode}");
            }
        }
    }
}
