using System;

namespace _05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMovie = int.Parse(Console.ReadLine());
            double hightRate = double.MinValue;
            double lowRate = double.MaxValue;
            double average = 0;
            string hightMovie = "";
            string lowMovie = "";

            for (int i = 0; i < numMovie; i++)
            {
                string movieName = Console.ReadLine();
                double rateMovie = double.Parse(Console.ReadLine());
                average += rateMovie;
                if (rateMovie > hightRate)
                {
                    hightMovie = movieName;
                    hightRate = rateMovie;
                }
                else if (rateMovie < lowRate)
                {
                    lowMovie = movieName;
                    lowRate = rateMovie;
                }
            }
            Console.WriteLine($"{hightMovie} is with highest rating: {hightRate:f1}");
            Console.WriteLine($"{lowMovie} is with lowest rating: {lowRate:f1}");
            Console.WriteLine($"Average rating: {average / numMovie:f1}");
        }
    }
}
