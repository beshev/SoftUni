using System;

namespace _02.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int serialMinutes = int.Parse(Console.ReadLine());
            int timeForBreak = int.Parse(Console.ReadLine());

            double timeLunch = 1.0 / 8 * timeForBreak;
            double timeRest = 1.0 / 4 * timeForBreak;
            double timeLeft = timeForBreak - (timeLunch + timeRest);
            if (timeLeft >= serialMinutes)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(timeLeft - serialMinutes)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(serialMinutes - timeLeft)} more minutes.");
            }
        }
    }
}
