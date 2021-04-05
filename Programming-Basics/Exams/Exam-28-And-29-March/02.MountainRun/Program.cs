using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForClaim = double.Parse(Console.ReadLine());

            double time = timeForClaim * distance;
            double timeSlow = Math.Floor(distance / 50);
            timeSlow *= 30;
            time += timeSlow;
            if (time >= record)
            {
                Console.WriteLine($"No! He was {time - record:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes! The new record is {time:f2} seconds.");
            }
        }
    }
}
