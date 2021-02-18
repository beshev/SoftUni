using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            string genre = Console.ReadLine();
            string doration = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "POPCORN!")
            {
                AddMovies(movies, input);
                input = Console.ReadLine();
            }
            movies = movies.OrderBy(x => doration == "Short" ? x.Time : -x.Time).ThenBy(x => x.Name).ToList();
            foreach (var movie in movies.Where(x => x.Genre == genre))
            {
                Console.WriteLine(movie.Name);
                string commnad = Console.ReadLine();
                if (commnad == "Yes")
                {
                    Console.WriteLine($"We're watching {movie.Name} - {movie.Time}");
                    Console.WriteLine($"Total Playlist Duration: {new TimeSpan(movies.Sum(x => x.Time.Ticks))}");
                    return;
                }
            }
        }


        static void AddMovies(List<Movie> movies, string movie)
        {

            string[] cmdArg = movie.Split('|', StringSplitOptions.RemoveEmptyEntries);
            string name = cmdArg[0];
            string currGenre = cmdArg[1];

            int[] array = cmdArg[2]
        .Split(':', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
            TimeSpan time = new TimeSpan(array[0], array[1], array[2]);
            movies.Add(new Movie(name, currGenre, time));

        }
    }

    class Movie
    {
        public Movie(string name, string genre, TimeSpan time)
        {
            Name = name;
            Genre = genre;
            Time = time;
        }

        public string Name { get; set; }

        public string Genre { get; set; }

        public TimeSpan Time { get; set; }
    }
}
