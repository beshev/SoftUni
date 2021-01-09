using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            decimal sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i].ToString();
                sum += MakeOperationByPositionOnLetters(currentString, 0);

            }
            Console.WriteLine($"{sum:f2}");
        }


        static decimal MakeOperationByPositionOnLetters(string currentString, int indexOf)
        {
            decimal number = decimal.Parse(currentString.Substring(1, currentString.Length - 2).ToString());
            for (int i = 0; i < 2; i++)
            {
                int letterPosition = (int)currentString[indexOf] % 32;
                bool isUpper = currentString[indexOf] >= 'A' && currentString[indexOf] <= 'Z';
                bool isLower = currentString[indexOf] >= 'a' && currentString[indexOf] <= 'z';
                if (indexOf == 0 && isUpper)
                {
                    number /= letterPosition;
                }
                else if (indexOf == 0 && isLower)
                {
                    number *= letterPosition;
                }
                else if (indexOf != 0 && isUpper)
                {
                    number -= letterPosition;
                }
                else if (indexOf != 0 && isLower)
                {
                    number += letterPosition;
                }
                indexOf = currentString.Length - 1;
            }
            return number;
        }
    }
}
