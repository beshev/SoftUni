using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.Robbery
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }

            var cameraNodes = new bool[nodes];

            Console.ReadLine()
                 .Split(' ')
                 .ToList()
                 .ForEach(x =>
                 {
                     var node = int.Parse(x[0].ToString());
                     var cameraPoint = x[1];

                     if (cameraPoint == 'w')
                     {
                         cameraNodes[node] = true;
                     }
                 });


            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var distance = new double[nodes];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            distance[startNode] = 0;

            var comparer = Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]));
            var bag = new OrderedBag<int>(comparer);

            bag.Add(startNode);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    var child = edge.First == minNode ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distance[child]) && cameraNodes[child] == false)
                    {
                        bag.Add(child);
                    }

                    var newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[child] && cameraNodes[child] == false)
                    {
                        distance[child] = newDistance;
                        bag = new OrderedBag<int>(bag, comparer);
                    }
                }
            }

            Console.WriteLine(distance[endNode]);
        }
    }
}
