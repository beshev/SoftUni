using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.EmergencyPlan
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public TimeSpan Time { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());

            var exits = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var edges = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var first = int.Parse(edgeData[0]);
                var second = int.Parse(edgeData[1]);

                var timeData = edgeData[2]
                    .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                var time = new TimeSpan(0, int.Parse(timeData[0]), int.Parse(timeData[1]));

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Time = time,
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }


            var targetTimeInfo = Console.ReadLine()
                .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

            var targetTime = new TimeSpan(00, int.Parse(targetTimeInfo[0]), int.Parse(targetTimeInfo[1]));

            for (int node = 0; node < nodes; node++)
            {
                var time = Dijkstra(node, exits, nodes);

                if (exits.Contains(node))
                {
                    continue;
                }

                if (time == TimeSpan.MaxValue)
                {
                    Console.WriteLine($"Unreachable {node} (N/A)");
                }
                else if (time <= targetTime)
                {
                    Console.WriteLine($"Safe {node} ({time})");
                }
                else if (time > targetTime)
                {
                    Console.WriteLine($"Unsafe {node} ({time})");
                }

            }
        }

        private static TimeSpan Dijkstra(int startNode, int[] exits, int nodes)
        {
            var distance = new TimeSpan[nodes];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = TimeSpan.MaxValue;
            }

            distance[startNode] = TimeSpan.Zero;

            var comparer = Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]));

            OrderedBag<int> bag = new OrderedBag<int>(comparer);
            bag.Add(startNode);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (exits.Contains(minNode))
                {
                    return distance[minNode];
                }

                foreach (var edge in graph[minNode])
                {
                    var child = edge.First == minNode ? edge.Second : edge.First;

                    if (distance[child] == TimeSpan.MaxValue)
                    {
                        bag.Add(child);
                    }

                    var newDistance = distance[minNode] + edge.Time;

                    if (newDistance < distance[child])
                    {
                        distance[child] = newDistance;

                        bag = new OrderedBag<int>(bag, comparer);
                    }
                }
            }

            return TimeSpan.MaxValue;
        }
    }
}
