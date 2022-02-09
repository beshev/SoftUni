namespace _01.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public double Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes, edges);

            var startNode = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.NegativeInfinity;
            }

            distance[startNode] = 100;

            var prev = new int[nodes];
            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = -1;
            }

            FindMostReliablePath(startNode, destination, distance, prev);

            var result = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                result.Push(node);
                node = prev[node];
            }

            Console.WriteLine($"Most reliable path reliability: {distance[destination]:f2}%");
            Console.WriteLine(string.Join(" -> ", result));
        }

        private static void FindMostReliablePath(int startNode, int destination, double[] distance, int[] prev)
        {
            var comparer = Comparer<int>.Create((f, s) => (int)(distance[s] - distance[f]));

            var bag = new OrderedBag<int>(comparer)
            {
                startNode
            };

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (double.IsNegativeInfinity(distance[minNode]))
                {
                    break;
                }

                if (minNode == destination)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    var from = edge.From;
                    var to = edge.To;
                    var weight = edge.Weight;

                    if (double.IsNegativeInfinity(distance[to]))
                    {
                        bag.Add(to);
                    }

                    var newDistace = distance[from] * weight / 100;

                    if (newDistace > distance[to])
                    {
                        distance[to] = newDistace;
                        prev[to] = from;
                        bag = new OrderedBag<int>(bag, comparer);
                    }
                }
            }
        }

        private static List<Edge>[] ReadGraph(int nodes, int edges)
        {
            var newGraph = new List<Edge>[nodes];

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];

                if (newGraph[from] == null)
                {
                    newGraph[from] = new List<Edge>();
                }

                if (newGraph[to] == null)
                {
                    newGraph[to] = new List<Edge>();
                }

                newGraph[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = edgeData[2]
                });

                newGraph[to].Add(new Edge
                {
                    From = to,
                    To = from,
                    Weight = edgeData[2]
                });
            }

            return newGraph;
        }
    }
}
