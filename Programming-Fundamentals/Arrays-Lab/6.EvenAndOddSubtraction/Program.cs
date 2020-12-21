using System;

namespace _6.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int[] numbers = new int[array.Length];
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                numbers[i] = int.Parse(array[i]);
                if (numbers[i] % 2 == 0)
                {
                    sumEven += numbers[i];
                }
                else
                {
                    sumOdd += numbers[i];
                }
            }
            Console.WriteLine(sumEven - sumOdd);
            
           
        }
    }
}
