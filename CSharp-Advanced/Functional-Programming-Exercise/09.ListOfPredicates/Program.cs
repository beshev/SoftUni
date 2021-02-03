using System;
using System.IO;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            Func<int[], int, bool> divisibleFilter = GetAllDivisible();
            Priter(divisibleFilter, length, array);
        }

        static void Priter(Func<int[], int, bool> divisibleFilter, int n, int[] array)
        {
            for (int i = 1; i <= n; i++)
            {
                if (divisibleFilter(array, i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        static Func<int[], int, bool> GetAllDivisible()
        {
            return (numbers, number) =>
            {
                foreach (var divisor in numbers)
                {
                    if (number % divisor != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
