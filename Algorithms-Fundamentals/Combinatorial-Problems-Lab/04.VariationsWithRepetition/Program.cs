using System;

namespace _04.VariationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            VariationsWithRepetitions();
        }

        private static void VariationsWithRepetitions(int index = 0)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                VariationsWithRepetitions(index + 1);
            }
        }
    }
}
