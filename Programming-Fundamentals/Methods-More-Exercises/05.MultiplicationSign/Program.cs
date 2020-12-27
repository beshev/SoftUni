using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            GetMultiplicatoinSign(first, second, third);
        }


        static void GetMultiplicatoinSign(int first, int second, int third)
        {
            int[] array = { first, second, third };
            int couterNegative = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    couterNegative++;
                }
            }
            bool isNegative = couterNegative == 1 || couterNegative == 3;
            bool isZero = first == 0 || second == 0 || third == 0;
            if (isZero)
            {
                Console.WriteLine("zero");
            }
            else if (isNegative)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
