using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintAllSymbolsBetweenTwoCharacters(first, second);
        }

        static void PrintAllSymbolsBetweenTwoCharacters(int first, int second)
        {
            int compare = first.CompareTo(second);
            if (compare > 0)
            {
                for (int i = second + 1; i < first; i++)
                {
                    Console.Write((char)(i) + " ");
                }

            }
            else
            {
                for (int i = first + 1; i < second; i++)
                {
                    Console.Write((char)(i) + " ");
                }
            }
        }
    }
}
