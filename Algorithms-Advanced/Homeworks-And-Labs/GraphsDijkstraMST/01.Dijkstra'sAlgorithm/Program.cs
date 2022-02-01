namespace _01.Dijkstra_sAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Wight { get; set; }
    }

    public class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] prev;

        static void Main()
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            var edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var edgesArg = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgesArg[0];
                var secondNode = edgesArg[1];

                if (edgesByNode.ContainsKey(firstNode) == false)
                {
                    edgesByNode.Add(firstNode, new List<Edge>());
                }

                if (edgesByNode.ContainsKey(secondNode) == false)
                {
                    edgesByNode.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge()
                {
                    First = firstNode,
                    Second = secondNode,
                    Wight = edgesArg[2],
                };

                edgesByNode[firstNode].Add(edge);
                edgesByNode[secondNode].Add(edge);
            }

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var biggestNode = edgesByNode.Keys.Max();

            distance = new double[biggestNode + 1];
            prev = new int[biggestNode + 1];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            for (int i = 0; i < distance.Length; i++)
            {
                prev[i] = -1;
            }

            distance[startNode] = 0;

            var comparer = Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s]));

            OrderedBag<int> bag = new OrderedBag<int>(comparer);
            bag.Add(startNode);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(distance[minNode]))
                {
                    break;
                }

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var edge in edgesByNode[minNode])
                {
                    var child = edge.Second;

                    if (double.IsPositiveInfinity(distance[child]))
                    {
                        bag.Add(child);
                    }

                    var newDistance = distance[minNode] + edge.Wight;

                    if (newDistance < distance[child])
                    {
                        distance[child] = newDistance;
                        prev[child] = minNode;

                        bag = new OrderedBag<int>(bag, comparer);
                    }
                }
            }

            if (double.IsPositiveInfinity(distance[endNode]))
            {
                Console.WriteLine("There is no such path.");
                
            }
            else
            {
                Console.WriteLine(distance[endNode]);

                var stack = new Stack<int>();

                var node = endNode;
                while (node != -1)
                {
                    stack.Push(node);
                    node = prev[node];
                }

                Console.WriteLine(string.Join(" ", stack));
            }
        }
    }
}
