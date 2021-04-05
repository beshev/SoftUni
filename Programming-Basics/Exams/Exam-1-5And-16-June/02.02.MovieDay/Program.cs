using System;

namespace _02._02.MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int timePictures = int.Parse(Console.ReadLine());
            int numActoins = int.Parse(Console.ReadLine());
            int timeForAction = int.Parse(Console.ReadLine());

            double totaTime = timePictures * 0.15;
            totaTime += numActoins * timeForAction;
            if (timePictures >= totaTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timePictures - totaTime)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {totaTime - timePictures} minutes.");
            }
        }
    }
}
