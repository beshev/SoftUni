using System;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            double[] numArr = new double[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numArr[i] = double.Parse(numbers[i]);               
            }
            for (int i = 0; i < numArr.Length; i++)
            {
                if (numArr[i] == 0)
                {
                    numArr[i] = 0;
                }
                Console.WriteLine($"{numArr[i]} => {(int)Math.Round(numArr[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
