using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSmallestNumber(numberOne,numberTwo,numberThree));
        }

        static int GetSmallestNumber(int numberOne, int numberTwo, int numberThree)
        {
            int[] array = {numberOne, numberTwo, numberThree};
            Array.Sort(array);
            int smallestNumber = array[0];
            return smallestNumber;
        }

    }
}
