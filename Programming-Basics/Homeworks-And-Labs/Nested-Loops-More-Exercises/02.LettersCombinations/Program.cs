using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char pass = char.Parse(Console.ReadLine());
            int counterAll = 0;
            // Find  All Combinations 
            for (char a = start; a <= end; a++)
            {
                for (char a1 = start; a1 <= end; a1++)
                {
                    for (char a3 = start; a3 <= end ; a3++)
                    {
                        // Find Combinations Without "PASS";
                        if (a == pass || a1 == pass || a3 == pass)
                        {
                            continue;
                        }
                        // Print all available Combinatoins and Find Sum of them
                        else
                        {
                            Console.Write($"{a}{a1}{a3} ");
                            counterAll++;
                        }
                    }
                }
            }
            Console.Write(counterAll);

        }
    }
}
