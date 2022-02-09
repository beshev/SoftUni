namespace _05.CableNetwork
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
        private static List<Edge>[] graph;
        private static HashSet<int> treeNodes;
        private static OrderedBag<Edge> bag;
        private static int budget;

        static void Main()
        {
            budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            treeNodes = new HashSet<int>();
            bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));


            for (int i = 0; i < edgesCount; i++)
            {
                var edgesArgs = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var firstNode = int.Parse(edgesArgs[0]);
                var secondNode = int.Parse(edgesArgs[1]);
                var weight = int.Parse(edgesArgs[2]);

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight,
                };

                if (edgesArgs.Length == 4)
                {
                    treeNodes.Add(firstNode);
                    treeNodes.Add(secondNode);
                }

                if (graph[firstNode] == null)
                {
                    graph[firstNode] = new List<Edge>();
                }

                if (graph[secondNode] == null)
                {
                    graph[secondNode] = new List<Edge>();
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            var budgetUsed = 0;

            foreach (var node in treeNodes)
            {
                bag.AddMany(graph[node]);
            }

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

                if (smallestEdge.Weight > budget)
                {
                    continue;
                }

                budgetUsed += smallestEdge.Weight;
                budget -= smallestEdge.Weight;

                treeNodes.Add(nonTreeNode);
                bag.AddMany(graph[nonTreeNode]);
            }

            Console.WriteLine($"Budget used: {budgetUsed}");

        }
    }
}
