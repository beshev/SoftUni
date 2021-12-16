using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.WordCruncher
{
    internal class Program
    {
        private static List<string> words;
        private static string targetString;
        private static HashSet<string> wordsSet = new HashSet<string>();

        static void Main(string[] args)
        {
            words = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            targetString = Console.ReadLine();

            WordCruncher();

            Console.WriteLine(String.Join(Environment.NewLine, wordsSet));
        }

        private static void WordCruncher(string currentString = "", string usedWords = "")
        {
            if (currentString == targetString)
            {
                wordsSet.Add(usedWords.TrimStart());
                return;
            }

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];
                var stringToAppend = currentString + currentWord;

                if (targetString.StartsWith(stringToAppend))
                {
                    words.RemoveAt(i);
                    WordCruncher(stringToAppend, usedWords + " " + currentWord);
                    words.Insert(i, currentWord);
                }
            }
        }
    }
}
