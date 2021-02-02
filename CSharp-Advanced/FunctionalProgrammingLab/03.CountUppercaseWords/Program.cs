using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> wordDelegate = GetWordsWithUppercase;
            string[] someText = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Where(wordDelegate)
                 .ToArray();
            Print(someText);
        }

        static void Print(string[] someText)
        {
            foreach (var word in someText)
            {
                Console.WriteLine(word);
            }
        }

        static bool GetWordsWithUppercase(string word)
        {
            return word[0] == word.ToUpper()[0];
        }
    }
}
