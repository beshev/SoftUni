using System;

namespace _01.SingOfIntegerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numebr = int.Parse(Console.ReadLine());
            SingNumber(numebr);
        }

        static void SingNumber(int number) 
        {
            if (number > 0) 
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }

    }
}
