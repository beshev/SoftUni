using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (symbol >= 'A' && symbol <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else if (symbol >= 'a' && symbol <= 'z')
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
