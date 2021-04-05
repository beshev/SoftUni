using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int maxPass = int.Parse(Console.ReadLine());
            char a = '#';
            char b = '@';
            int counterPass = 0;

            // Template = "ABxyBA" -> OK


            // Find Number X -> 1 <= x
            for (int X = 1; X <= x; X++)
            {
                // Find Number Y -> 1 <= y;
                for (int Y = 1; Y <= y; Y++)
                {
                    Console.Write($"{a}{b}{X}{Y}{b}{a}|");
                    counterPass++;
                    if (counterPass == maxPass)
                    {
                        return;
                    }
                    a++;
                    b++;
                    if (a > 55)
                    {
                        a = '#';
                    }
                    if (b > 96)
                    {
                        b = '@';
                    }
                }

            }



        }
    }
}
