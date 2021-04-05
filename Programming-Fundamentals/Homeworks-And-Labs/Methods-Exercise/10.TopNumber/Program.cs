using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                if (CheckSumOfAllDigitsDivideBy8(i) && CheckHaveOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool CheckSumOfAllDigitsDivideBy8(int number)
        {
            bool isDivide = false;
            string digits = number.ToString();
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += int.Parse(digits[i].ToString());
            }
            if (sum % 8 == 0)
            {
                isDivide = true;
            }
            return isDivide;
        }

        static bool CheckHaveOneOddDigit(int number)
        {
            bool haveOddDigit = false;
            string digits = number.ToString();
            for (int i = 0; i < digits.Length; i++)
            {
                if (int.Parse(digits[i].ToString()) % 2 != 0)
                {
                    haveOddDigit = true;
                      break;
                }
            }
            return haveOddDigit;
        }
    }
}
