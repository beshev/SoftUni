using System;
using System.Globalization;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            while (input != "END")
            {

                bool isInteger = int.TryParse(input, out _);
                bool isFloating = float.TryParse(input, out _);
                bool isCharacter = char.TryParse(input, out _);
                bool isBoleand = bool.TryParse(input, out _);
                if (isInteger)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (isFloating)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isCharacter)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (isBoleand)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }     
                input = Console.ReadLine();
            }


        }
    }
}
