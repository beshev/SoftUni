using System;

namespace _01.IntegerOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int numberfour = int.Parse(Console.ReadLine());
            int sumOfNumberOneAndNumberTwo = numberTwo + numberOne;
            int sumNumberThree = sumOfNumberOneAndNumberTwo / numberThree;
            int totalSum = sumNumberThree * numberfour;

            Console.WriteLine(totalSum);

        }
    }
}
