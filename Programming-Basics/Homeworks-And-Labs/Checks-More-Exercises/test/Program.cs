using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());

            int workDays = 365 - restDays;
            int timeForPlay = workDays * 63 + restDays * 127;
            int difference = 30000 - timeForPlay;
            int hours = Math.Abs(difference / 60);
            int minutes = Math.Abs(difference % 60);

            if (timeForPlay > 30000 )
            {

                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else 
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }


        }
    }
}
