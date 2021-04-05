using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    firstArray[i] = numbers[0];
                    secondArray[i] = numbers[1];
                }
                else
                {
                    secondArray[i] = numbers[0];
                    firstArray[i] = numbers[1];
                }
            }
            foreach (var item in firstArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in secondArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
