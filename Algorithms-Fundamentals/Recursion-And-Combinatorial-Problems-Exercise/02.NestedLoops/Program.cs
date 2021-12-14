using System;

namespace _02.NestedLoops
{
    internal class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            elements = new int[n];

            SimulatesExecution();
        }

        private static void SimulatesExecution(int index = 0)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(' ', elements));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                elements[index]++;
                SimulatesExecution(index + 1);
            }

            elements[index] = 0;
        }
    }
}
