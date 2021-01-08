using System;
using System.Text;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder characters = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    digits.Append(input[i]);
                }
                else if (char.IsLetter(currentChar))
                {
                    letters.Append(input[i]);
                }
                else
                {
                    characters.Append(input[i]);
                }
            }
            Console.WriteLine($"{digits}\n{letters}\n{characters}");
        }
    }
}
