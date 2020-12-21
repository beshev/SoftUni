using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numSeasons = int.Parse(Console.ReadLine());
            int numEpisodes = int.Parse(Console.ReadLine());
            int timeForOneEpisode = int.Parse(Console.ReadLine());
            double timeWithАdvertising = timeForOneEpisode + (timeForOneEpisode * 0.2);

            double timeForEpisodes = (numEpisodes - 1) * timeWithАdvertising * numSeasons;
            double timeLastEpisode = (timeForOneEpisode + 10) + (timeForOneEpisode * 0.2);
            timeLastEpisode *= numSeasons;
            double totalTime = timeForEpisodes + timeLastEpisode;

            Console.WriteLine($"Total time needed to watch the {name} series is {Math.Floor(totalTime) } minutes.");
        }
    }
}
