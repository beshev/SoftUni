using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int number = 1; number <= n; number++)
            {
                int sumOfDigits = 0;
                int currentNumber = number;
                while (currentNumber > 0)
                {
                    sumOfDigits += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }
                bool IsTrue = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", number, IsTrue);
            }


        }
    }
}
