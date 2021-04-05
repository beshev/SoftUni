using System;

namespace _09.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 0;
            int hour = 0;

            for (int i = 0; i <= 23; i++)
            {
                for (int u = 0; u <= 59; u++)
                {

                    Console.WriteLine($"{hour}:{minutes}");
                    minutes++;

                }
                minutes = 0;
                hour++;
            }
        }
    }
}
