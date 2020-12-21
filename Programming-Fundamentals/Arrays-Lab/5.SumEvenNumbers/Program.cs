using System;

namespace _5.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int[] numArr = new int[array.Length];
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                numArr[i] = int.Parse(array[i]);
            }
            for (int i = 0; i < numArr.Length; i++)
            {
                if (numArr[i] % 2 == 0)
                {
                    sum += numArr[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
