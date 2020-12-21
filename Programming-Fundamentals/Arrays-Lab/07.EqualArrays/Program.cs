using System;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();
            int sumOfArrays = 0;
            int[] numbers1 = new int[array1.Length];
            int[] numbers2 = new int[array2.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                numbers1[i] = int.Parse(array1[i]);
                numbers2[i] = int.Parse(array2[i]);
            }
            for (int i = 0; i < array2.Length; i++)
            {
                if (numbers1[i] == numbers2[i])
                {
                    sumOfArrays += numbers1[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sumOfArrays}");
        }
    }
}
