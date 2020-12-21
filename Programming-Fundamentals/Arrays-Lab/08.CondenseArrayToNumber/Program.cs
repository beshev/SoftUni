using System;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int[] numbers = new int[array.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(array[i]);
            }

            while (numbers.Length != 1)
            {
                int[] newArr = new int[numbers.Length - 1];
                for (int j = 0; j < newArr.Length; j++)
                {
                    newArr[j] = numbers[j] + numbers[j + 1];
                }
                numbers = newArr;
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
