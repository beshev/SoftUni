using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(CounterVowelsdDigits(input));
        }

        static int CounterVowelsdDigits(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool isVowels = input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u' ||
                    input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U';
                if (isVowels)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
