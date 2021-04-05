using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;
            while (number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
