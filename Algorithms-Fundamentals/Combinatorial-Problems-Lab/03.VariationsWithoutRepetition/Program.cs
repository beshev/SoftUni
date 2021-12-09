using System;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

            Variations();
        }

        private static void Variations(int index = 0)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
