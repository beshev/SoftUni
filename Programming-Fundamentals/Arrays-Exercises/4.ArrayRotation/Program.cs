using System;
using System.Linq;

namespace _4.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersOfRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersOfRotations; i++)
            {
                int temp = numbers[0];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[numbers.Length - 1] = temp;

            }
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }

        }
    }
}
