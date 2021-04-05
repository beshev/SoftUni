using System;

namespace _05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numbersOfSymbols = int.Parse(Console.ReadLine());
            string decrytingWord = "";
            for (int i = 0; i < numbersOfSymbols; i++)
            {
                char symbols = char.Parse(Console.ReadLine());;
                decrytingWord += Convert.ToString((char)(symbols + key));
            }
            Console.WriteLine(decrytingWord);
        }
    }
}
