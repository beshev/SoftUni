using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine();
            int maxLen = 0;
            for (int i = 0; i < list.Length; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(i, i, list));
            }
            for (int i = 0; i < list.Length - 1; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(i, i + 1, list));
            }
            Console.WriteLine(maxLen);
        }

        static int PalindromeLen(int leftIndex, int rightIndex, string letters)
        {
            while ((leftIndex >= 0 && rightIndex < letters.Length)
                && (letters[leftIndex] == letters[rightIndex]))
            {
                leftIndex--;
                rightIndex++;
            }
            return rightIndex - leftIndex - 1;
        }
    }
}