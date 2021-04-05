using System;

namespace _10.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 0;
            int hour = 0;
            int seconds = 0;

            for (int h = 0; h <= 23; h++)
            {
                for (int m = 0; m <= 59; m++)
                {
                    for (int s = 0; s <= 59; s++)
                    {
                        Console.WriteLine($"{hour} : {minutes} : {seconds}");
                        seconds++;
                    }
                    seconds = 0;    
                    minutes++;

                }
                minutes = 0;
                hour++;
            }
        }
    }
}
