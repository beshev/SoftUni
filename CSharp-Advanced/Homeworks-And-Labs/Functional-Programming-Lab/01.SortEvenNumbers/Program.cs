using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(GetEvenNumbers)
                .OrderBy(x => x)
                .ToArray();
            Console.WriteLine(string.Join(", ", numbers));
        }

        static bool GetEvenNumbers(int number)
        {
            return number % 2 == 0;
        }
    }
}
