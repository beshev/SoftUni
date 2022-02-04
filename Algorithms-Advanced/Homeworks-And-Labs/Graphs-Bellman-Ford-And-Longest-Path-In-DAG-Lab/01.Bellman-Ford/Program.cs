using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BellmanFord
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }


    internal class Program
    {
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var edgesByNode = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                edgesByNode.Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            var prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            distance[start] = 0;

            for (int node = 0; node < nodes - 1; node++)
            {
                foreach (var edge in edgesByNode)
                {
                    var from = edge.From;
                    var to = edge.To;

                    if (double.IsPositiveInfinity(distance[from]))
                    {
                        continue;
                    }

                    var newDistance = distance[from] + edge.Weight;
                    if (newDistance < distance[to])
                    {
                        distance[to] = newDistance;
                        prev[to] = from;
                    }
                }
            }

            foreach (var edge in edgesByNode)
            {
                var from = edge.From;
                var to = edge.To;

                var newDistance = distance[from] + edge.Weight;
                if (newDistance < distance[to])
                {
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }

            var path = new Stack<int>();

            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(string.Join(' ', path));
            Console.WriteLine(distance[destination]);
        }
    }
}
