using System;
using System.Linq;

namespace _7.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string maxSequenses = "";

            for (int i = 0; i < numbers.Length; i++)
            {
            string sequenses = "";
                int counterSequenses = 1;
                for (int j = i; j < numbers.Length - 1; j++)
                {
                    if (numbers[i] == numbers[j + 1])
                    {
                        counterSequenses++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int j = 0; j < counterSequenses; j++)
                {
                    sequenses += numbers[i] + " ".ToString();
                }
                if (sequenses.Length > maxSequenses.Length)
                {
                    maxSequenses = sequenses;
                }

            }
            Console.WriteLine(maxSequenses);
        }
    }
}
