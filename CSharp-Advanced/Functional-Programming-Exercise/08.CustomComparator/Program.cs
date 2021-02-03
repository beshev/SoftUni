using System;
using System.IO;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
            Array.Sort(numbers);
            Action<int[]> filterAndPrinter = FilterAndPrinter(GetEven());
            filterAndPrinter(numbers);
            filterAndPrinter = FilterAndPrinter(GetOdd());
            filterAndPrinter(numbers);

        }

        static Action<int[]> FilterAndPrinter(Func<int, bool> filter)
        {
            return numbers =>
            {
                foreach (var number in numbers)
                {
                    if (filter(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            };
        }

        static Func<int, bool> GetEven()
        {
            return number => number % 2 == 0;
        }

        static Func<int, bool> GetOdd()
        {
            return number => number % 2 != 0;
        }
    }
}
