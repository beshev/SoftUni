using System;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            RemoveRepeatingChars(input);
        }

        static void RemoveRepeatingChars(string someText)
        {
            int counter = 0;
            for (int i = 0; i < someText.Length; i++)
            {
                for (int j = i + 1; j < someText.Length; j++)
                {
                    if (someText[i] == someText[j])
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                someText = someText.Remove(i + 1, counter);
                counter = 0;
            }
            Console.WriteLine(someText);
        }
    }
}
