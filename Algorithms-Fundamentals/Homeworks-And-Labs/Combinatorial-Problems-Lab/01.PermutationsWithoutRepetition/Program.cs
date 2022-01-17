using System;

namespace _01.PermutationsWithoutRepetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ');

            Permutations(elements);
        }

        private static void Permutations(string[] elements, int index = 0)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));

                return;
            }

            Permutations(elements, index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(elements, index, i);
                Permutations(elements, index + 1);
                Swap(elements, index, i);
            }
        }

        private static void Swap(string[] elements, int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
