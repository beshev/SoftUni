using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Ceiling(GetSumOfTwoNumbers(first, @operator, second)));
        }

        static double GetSumOfTwoNumbers (double first, char symbol,double second) 
        {
            double sum = 0;
            if (symbol == '+')
            {
                sum = first + second;
            }
            else if (symbol == '-')
            {
                sum = first - second;
            }
            else if (symbol == '*')
            {
                sum = first * second;
            }
            else if (symbol == '/')
            {
                sum = first - second;
            }           
            return sum;
        }
    }
}
