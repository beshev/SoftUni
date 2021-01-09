using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                MutiplyBigInteger(number, digit);
            }
        }

        static void MutiplyBigInteger(string number, int digit)
        {
            int couter = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '0')
                {
                    couter++;
                }
                else
                {
                    break;
                }
            }
            number = number.Remove(0,couter);
            int temp = 0;
            int digitToAdd = 0;
            StringBuilder result = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int numberDigit = int.Parse(number[i].ToString());
                if (i == 0)
                {
                    digitToAdd = (numberDigit * digit) + temp;
                    result.Insert(0, digitToAdd);
                }
                else if (numberDigit * digit >= 10)
                {
                    digitToAdd = (numberDigit * digit + temp) % 10;
                    temp = (numberDigit * digit + temp) / 10;
                    result.Insert(0, digitToAdd);
                }
                else
                {
                    if ((numberDigit * digit) + temp >= 10)
                    {
                        digitToAdd = (numberDigit * digit + temp) % 10;
                        temp = ((numberDigit * digit) + temp) / 10;
                    }
                    else
                    {
                        digitToAdd = (numberDigit * digit) + temp;
                        temp = 0;
                    }
                    result.Insert(0, digitToAdd);
                }
            }
            Console.WriteLine(result);
        }
    }
}
