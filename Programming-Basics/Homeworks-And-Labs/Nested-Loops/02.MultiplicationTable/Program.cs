using System;

namespace _09.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 1;
            int hour = 1;

            for (int i = 1; i <= 10; i++)
            {
                for (int u = 1; u <= 10; u++)
                {
                    int sum = hour * minutes;
                    Console.WriteLine($"{hour} * {minutes} = {sum}");
                    minutes++;

                }
                minutes = 1;
                hour++;
            }
        }
    }
}
