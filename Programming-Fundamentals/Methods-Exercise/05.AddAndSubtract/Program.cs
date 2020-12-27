using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine(SubtractThirdNumberFromFirstAndSecond(first, second, third));
        }

        static int AddFirstAndSecondNumbers(int first, int second) 
        {
            int sum = first + second;
            return sum;
        }

        static int SubtractThirdNumberFromFirstAndSecond(int first, int second, int third) 
        {
            int sum = AddFirstAndSecondNumbers(first, second) - third;
            return sum;
        }
    }
}
