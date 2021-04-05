using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> alphabetic = new Dictionary<string, char>();
            alphabetic.Add(".-", 'a');
            alphabetic.Add("-...", 'b');
            alphabetic.Add("-.-.", 'c');
            alphabetic.Add("-..", 'd');
            alphabetic.Add(".", 'e');
            alphabetic.Add("..-.", 'f');
            alphabetic.Add("--.", 'g');
            alphabetic.Add("....", 'h');
            alphabetic.Add("..", 'i');
            alphabetic.Add(".---", 'j');
            alphabetic.Add("-.-", 'k');
            alphabetic.Add(".-..", 'l');
            alphabetic.Add("--", 'm');
            alphabetic.Add("-.", 'n');
            alphabetic.Add("---", 'o');
            alphabetic.Add(".--.", 'p');
            alphabetic.Add("--.-", 'q');
            alphabetic.Add(".-.", 'r');
            alphabetic.Add("...", 's');
            alphabetic.Add("-", 't');
            alphabetic.Add("..-", 'u');
            alphabetic.Add("...-", 'v');
            alphabetic.Add(".--", 'w');
            alphabetic.Add("-..-", 'x');
            alphabetic.Add("-.--", 'y');
            alphabetic.Add("--..", 'z');

            string[] morseCode = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            StringBuilder result = new StringBuilder();

            foreach (var word in morseCode)
            {
                if (word != "|")
                {
                    result.Append(alphabetic[word]);
                }
                else
                {
                    result.Append(" ");
                }
            }
            Console.WriteLine(result.ToString().ToUpper());
        }
    }
}
