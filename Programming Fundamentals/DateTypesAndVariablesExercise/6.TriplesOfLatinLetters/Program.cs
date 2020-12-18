using System;

namespace _6.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char j = 'a'; j < 'a' + n; j++)
                {
                    for (char y = 'a'; y < 'a' + n; y++)
                    {
                        Console.WriteLine($"{i}{j}{y}");
                    }
                }
            }
        }
    }
}
