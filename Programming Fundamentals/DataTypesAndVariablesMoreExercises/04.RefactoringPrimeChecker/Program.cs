using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersChecks = int.Parse(Console.ReadLine());
            for (int currentNum = 2; currentNum <= numbersChecks; currentNum++)
            {
                string isPrime = "false";
                int counterDividers = 1;
                for (int divider = 2; divider <= currentNum; divider++)
                {
                    if (currentNum % divider == 0)
                    {
                        counterDividers++;
                    }
                }
                if (counterDividers == 2)
                {
                    isPrime = "true";

                }
                Console.WriteLine($"{currentNum} -> {isPrime}");
            }
        }
    }
}
