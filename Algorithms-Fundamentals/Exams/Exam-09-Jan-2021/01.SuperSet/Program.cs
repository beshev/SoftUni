using System;

namespace _01.SuperSet
{
    internal class Program
    {
        private static string[] arr;
        private static string[] combinations;

        static void Main(string[] args)
        {
            arr = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                combinations = new string[i];

                Combinations();
            }


            Console.WriteLine(string.Join(' ', arr));
        }

        private static void Combinations(int index = 0, int start = 0)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }


            for (int i = start; i < arr.Length; i++)
            {
                combinations[index] = arr[i];
                Combinations(index + 1, i + 1);
            }
        }
    }
}
