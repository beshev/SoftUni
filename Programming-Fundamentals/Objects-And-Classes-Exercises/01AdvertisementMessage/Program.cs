using System;

namespace _01AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{Phrases.phrases[random.Next(0, Phrases.phrases.Length)]}" +
                    $" {Events.events[random.Next(0, Events.events.Length)]} " +
                    $"{Authors.authors[random.Next(0, Authors.authors.Length)]}" +
                    $" – {Cities.cities[random.Next(0, Cities.cities.Length)]}.");
            }

        }
    }

    public class Phrases
    {
        public static string[] phrases =
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can’t live without this product."
        };
    }

    public class Events
    {
        public static string[] events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };
    }

    public class Authors
    {
        public static string[] authors =
           {
            "Diana",
            "Petya",
            "Stella",
            "Elena",
            "Katya",
            "Iva",
            "Annie",
            "Eva"
        };
    }

    public class Cities
    {
      public static  string[] cities =
        {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };
    }
}
