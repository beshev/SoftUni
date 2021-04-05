using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            CalculationBetweenTwoNumbers(firstNum , secondNum , operation);
        }

        static void CalculationBetweenTwoNumbers(int first, int second, string operation) 
        {
            if (operation == "subtract")
            {
                Console.WriteLine(first - second);
            }
            else if (operation == "add")
            {
                Console.WriteLine(first + second);
            }
            else if (operation == "multiply")
            {
                Console.WriteLine(first * second);
            }
            else if (operation == "divide")
            {
                Console.WriteLine(first / second);
            }
        }
    }
}
