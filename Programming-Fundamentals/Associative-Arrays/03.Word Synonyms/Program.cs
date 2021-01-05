using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int allWords = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            for (int i = 0; i < allWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonym);
                }
                else
                {
                    synonyms.Add(word, new List<string>() { synonym });
                }
            }
            foreach (var word in synonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ",word.Value)}");
            }
        }
    }
}
