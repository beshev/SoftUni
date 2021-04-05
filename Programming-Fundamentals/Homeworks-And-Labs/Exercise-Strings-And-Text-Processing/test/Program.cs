using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main()
        {
            char c = 'a';
            int index = (int)c % 32;
            Console.WriteLine(index);
        }
    }
}