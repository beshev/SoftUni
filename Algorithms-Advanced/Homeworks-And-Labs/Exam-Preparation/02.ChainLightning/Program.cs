namespace _02.ChainLightning
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
        private static int[] damageTaken;
        private static int[] nodesDamage;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            var lightning = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];
            damageTaken = new int[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgesArgs = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
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

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            for (int i = 0; i < lightning; i++)
            {
                treeNodes = new HashSet<int>();
                nodesDamage = new int[nodes];

                var data = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var startNode = data[0];
                var damage = data[1];

                Prim(startNode, damage);
            }

            Console.WriteLine(damageTaken.Max());
        }

        private static void Prim(int startNode, int damage)
        {
            treeNodes.Add(startNode);
            nodesDamage[startNode] = damage;
            damageTaken[startNode] += damage;

            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            bag.AddMany(graph[startNode]);

            while (bag.Count > 0)
            {
                var smallestEdge = bag.RemoveFirst();

                var firstNode = smallestEdge.First;
                var secondNode = smallestEdge.Second;

                var nonTreeNode = -1;
                var parentNode = -1;

                if (treeNodes.Contains(firstNode)
                    && treeNodes.Contains(secondNode) == false)
                {
                    nonTreeNode = secondNode;
                    parentNode = firstNode;
                }

                if (treeNodes.Contains(secondNode)
                   && treeNodes.Contains(firstNode) == false)
                {
                    nonTreeNode = firstNode;
                    parentNode = secondNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                var currentDamage = nodesDamage[parentNode] / 2;

                damageTaken[nonTreeNode] += currentDamage;
                nodesDamage[nonTreeNode] = currentDamage;

                treeNodes.Add(nonTreeNode);
                bag.AddMany(graph[nonTreeNode]);
            }
        }
    }
}
