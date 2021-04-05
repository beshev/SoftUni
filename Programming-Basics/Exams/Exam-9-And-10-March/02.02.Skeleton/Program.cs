using System;

namespace _02._02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double leightMeters = double.Parse(Console.ReadLine());
            int secondsFor100 = int.Parse(Console.ReadLine());

            minutes *= 60;
            seconds += minutes;

            double timeSlow = (leightMeters / 120) * 2.5;
            double totalTime = (leightMeters / 100) * secondsFor100 - timeSlow;

            if (totalTime <= seconds)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {totalTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {totalTime - seconds:f3} second slower.");
            }


        }
    }
}
