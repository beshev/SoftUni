using System;
using System.Linq;

namespace _8.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int givenNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length - 1; j++)
                {
                    bool isUnique = numbers[i] + numbers[j + 1] == givenNumber;
                    if (isUnique)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j + 1]}");
                    }

                }
            }
        }
    }
}
