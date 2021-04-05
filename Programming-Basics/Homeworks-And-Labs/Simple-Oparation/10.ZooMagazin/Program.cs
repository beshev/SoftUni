using System;

namespace ZooMagazin
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());
            double sum = (dogs * 2.50) + (animals * 4);

            Console.WriteLine($"{sum} lv.");
        }
    }
}
