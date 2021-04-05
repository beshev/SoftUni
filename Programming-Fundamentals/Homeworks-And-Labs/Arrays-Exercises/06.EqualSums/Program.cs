using System;
using System.Linq;

namespace _06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int index = 0; index < numbers.Length; index++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int leftsDigits = 0; leftsDigits < index; leftsDigits++)
                {
                    leftSum += numbers[leftsDigits];
                }
                for (int rightDigits = 0; rightDigits < numbers.Length - index - 1; rightDigits++)
                {
                    rightSum += numbers[(index + 1) + rightDigits];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine($"{index}");
                    return;
                }
            }
            bool isTrue = numbers.Length == 1;
            if (isTrue)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
