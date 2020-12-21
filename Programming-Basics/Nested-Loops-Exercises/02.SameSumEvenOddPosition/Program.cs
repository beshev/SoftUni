using System;

namespace _02.SameSumEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = num1; i <= num2; i++)
            {
                string currentNum = i.ToString();

                for (int y = 0; y < currentNum.Length; y++)
                {
                    int currentDigit = int.Parse(currentNum[y].ToString());
                    if (y % 2 == 0)
                    {
                        sumEven += currentDigit;
                    }
                    else
                    {
                        sumOdd += currentDigit;
                    }

                }
                if (sumEven == sumOdd)
                {
                    Console.Write(i + " ");
                }
                sumOdd = 0;
                sumEven = 0;



            }
        }
    }
}
