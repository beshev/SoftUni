using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = FillDictionary();
            var lines = File.ReadLines("../../../input.txt");
            foreach (var line in lines)
            {
                var currentWords = line.Split(new char[] { ' ', '.', '!', '?', '-', ',' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in currentWords.Select(x => x.ToLower()))
                {
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
            }

            FileWriter(words);
        }

        private static void FileWriter(Dictionary<string, int> words)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                sb.AppendLine($"{word.Key} - {word.Value}");
            }
            File.WriteAllText("../../../actualResult.txt", sb.ToString());
            sb.Clear();
            foreach (var word in words.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{word.Key} - {word.Value}");
            }
            File.WriteAllText("../../../expectedResult.txt", sb.ToString());
        }

        public static Dictionary<string, int> FillDictionary()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            Queue<string> wordsQueue = new Queue<string>(File.ReadAllLines("../../../words.txt"));
            while (wordsQueue.Count > 0)
            {
                words.Add(wordsQueue.Dequeue(), 0);
            }
            return words;
        }
    }
}
