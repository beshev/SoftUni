using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Randomizer resul = new Randomizer();
            resul.words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            resul.RandomizerWords();
            resul.PrintWords();
        }

    }

    public class Randomizer
    {
        public List<string> words;
        public void RandomizerWords()
        {
            Random resul = new Random();
            for (int i = 0; i < words.Count; i++)
            {
                int randomPosition = resul.Next(0, words.Count);
                string temp = words[i];
                this.words[i] = this.words[randomPosition];
                this.words[randomPosition] = temp;
            }
        }

        public void PrintWords()
        {
            Console.WriteLine(String.Join(Environment.NewLine, words));
        }

    }
}
