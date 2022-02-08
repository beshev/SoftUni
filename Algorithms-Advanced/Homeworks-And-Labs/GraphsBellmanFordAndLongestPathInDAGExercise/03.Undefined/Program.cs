using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Undefined
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public double Weight { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            var prev = new int[nodes + 1];
            var edges = new List<Edge>();

            for (int i = 1; i < prev.Length; i++)
            {
                prev[i] = -1;
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];

                edges.Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                });
            }

            var startNode = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            distance[startNode] = 0;

            for (int node = 1; node <= nodes - 1; node++)
            {
                foreach (var edge in edges)
                {
                    var first = edge.First;
                    var second = edge.Second;

                    if (double.IsPositiveInfinity(distance[first]))
                    {
                        continue;
                    }

                    var newDistance = distance[first] + edge.Weight;

                    if (newDistance < distance[second])
                    {
                        distance[second] = newDistance;
                        prev[second] = first;
                    }
                }
            }

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                var newDistance = distance[first] + edge.Weight;

                if (newDistance < distance[second])
                {
                    Console.WriteLine("Undefined");
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
