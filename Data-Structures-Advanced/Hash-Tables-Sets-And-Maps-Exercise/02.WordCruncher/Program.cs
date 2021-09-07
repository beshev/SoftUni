using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    class Program
    {
        private static HashSet<string> actualResult = new HashSet<string>();

        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string word = Console.ReadLine();

            WordCruncher(input, word);

            foreach (var result in actualResult.OrderBy(x => x))
            {
                Console.WriteLine(result);
            }

        }

        private static void WordCruncher(List<string> input, string word, string currentResult = "")
        {
            var currentWord = currentResult.Replace(" ", null);

            if (currentWord == word)
            {
                actualResult.Add(currentResult.TrimStart());
                return;
            }

            foreach (var startLetters in input)
            {
                if (word.StartsWith(currentWord + startLetters))
                {
                    List<string> startInput = new List<string>(input);
                    startInput.Remove(startLetters);

                    WordCruncher(startInput, word, currentResult + " " + startLetters);
                }
            }
        }
    }
}

