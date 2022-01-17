using System;
using System.Collections.Generic;

namespace _02.PermutationsWithRepetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            PermutationsWithRepetition(elements);
        }

        private static void PermutationsWithRepetition(string[] elements, int index = 0)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            PermutationsWithRepetition(elements, index + 1);
            var swapped = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (swapped.Contains(elements[i]) == false)
                {
                    Swap(elements, index, i);
                    PermutationsWithRepetition(elements, index + 1);
                    Swap(elements, index, i);
                    swapped.Add(elements[i]);
                }
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
