using System;

namespace _03.Generating01Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[] vectors = new int[n];

            GenerateVectors(vectors, 0);
        }

        private static void GenerateVectors(int[] vectors, int index)
        {
            if (index == vectors.Length)
            {
                Console.WriteLine(String.Join("",vectors));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vectors[index] = i;
                GenerateVectors(vectors, index + 1);
            }
        }
    }
}
