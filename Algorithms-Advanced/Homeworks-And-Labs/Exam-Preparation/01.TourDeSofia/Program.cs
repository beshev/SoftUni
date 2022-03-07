namespace _01.TourDeSofia
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
        private static List<Edge>[] edgesByNode;
        private static double[] distance;
        private static int[] prev;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            var startNode = int.Parse(Console.ReadLine());

            edgesByNode = new List<Edge>[nodes];

            for (int i = 0; i < nodes; i++)
            {

                edgesByNode[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgesArg = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgesArg[0];
                var secondNode = edgesArg[1];

                var edge = new Edge()
                {
                    First = firstNode,
                    Second = secondNode,
                    Wight = edgesArg[2],
                };

                edgesByNode[firstNode].Add(edge);
            }

            distance = new double[nodes];
            prev = new int[nodes];

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

            bool isFist = true;

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (minNode == startNode && isFist == false)
                {
                    break;
                }

                isFist = false;

                foreach (var edge in edgesByNode[minNode])
                {
                    var child = edge.Second;

                    if (double.IsPositiveInfinity(distance[child]))
                    {
                        bag.Add(child);
                    }

                    var newDistance = distance[minNode] + edge.Wight;

                    if (child == startNode
                        && distance[child] == 0)
                    {
                        distance[child] = newDistance;
                    }

                    if (newDistance < distance[child])
                    {
                        distance[child] = newDistance;
                        prev[child] = minNode;

                        bag = new OrderedBag<int>(bag, comparer);
                    }
                }
            }

            if (distance[startNode] == 0)
            {
                Console.WriteLine(distance.Count(x => x != double.PositiveInfinity));
            }
            else
            {
                Console.WriteLine(distance[startNode]);
            }
        }
    }
}
