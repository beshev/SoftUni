using System;
using System.Globalization;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(CheckNumbersIsPalindrom(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        static bool CheckNumbersIsPalindrom(string input)
        {
            bool IsPalindrom = true;
            for (int i = 0; i < input.Length / 2; i++)
            {
                int compare = input[i].CompareTo(input[input.Length - i - 1]);
                if (compare != 0)
                {
                    IsPalindrom = false;
                }

            }
            return IsPalindrom;
        }
    }
}
