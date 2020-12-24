using System;
using System.Numerics;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            decimal secondNumber = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"{DivideSumOfTwoFactorialNumbers(firstNumber, secondNumber):f2}");
        }

        static decimal FactorialOfTheFirstNumber(decimal first)
        {
            decimal sum = 1;
            for (int i = 1; i <= first; i++)
            {
                sum *= i;
            }
            return sum;
        }

        static decimal FactorialOfTheSecondNumber(decimal second)
        {
            decimal sum = 1;
            for (int i = 1; i <= second; i++)
            {
                sum *= i;
            }
            return sum;
        }

        static decimal DivideSumOfTwoFactorialNumbers(decimal first, decimal second)
        {
            decimal firstSum = FactorialOfTheFirstNumber(first);
            decimal secondSum = FactorialOfTheSecondNumber(second);
            decimal sum = (decimal)firstSum / (decimal)secondSum;
            return sum;
        }
    }
}
