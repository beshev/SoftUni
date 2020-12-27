using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCharacter(input);
        }

        static void PrintMiddleCharacter(string input)
        {
            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[(input.Length / 2)].ToString());
            }
            else
            {
                Console.Write(input[(input.Length / 2) - 1].ToString() + input[(input.Length / 2)].ToString());
            }
        }
    }
}
