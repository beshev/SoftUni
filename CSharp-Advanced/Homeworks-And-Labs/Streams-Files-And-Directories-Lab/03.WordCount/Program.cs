using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsCount = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string[] words = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();
                foreach (var word in words)
                {
                    if (wordsCount.ContainsKey(word) == false)
                    {
                        wordsCount.Add(word, 0);
                    }
                }
            }
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string currentText = reader.ReadLine();
                while (currentText != null)
                {
                    string[] currentWords = currentText
                                             .Split(new char[] { ' ', '.', '-', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(x => x.ToLower())
                                             .ToArray();

                    foreach (var word in currentWords)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }

                    }
                    currentText = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                    Console.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
