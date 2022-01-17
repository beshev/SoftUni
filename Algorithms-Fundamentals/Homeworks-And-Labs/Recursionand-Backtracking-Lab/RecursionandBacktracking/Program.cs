using System;
using System.Linq;

namespace RecursionandBacktracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            Console.WriteLine(GetSum(array));
        }

        public static int GetSum(int[] array, int index = 0)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + GetSum(array, index + 1);
        }
    }
}
