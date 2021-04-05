using System;

namespace _8.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string kegModel = "";
            // Information For First Keg
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                uint height = uint.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    kegModel = model;
                }
            }
            Console.WriteLine($"{kegModel}");
        }
    }
}
