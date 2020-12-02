using System;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());
            double sum = (C * 1.8 + 32);

            Console.WriteLine($"{sum:f2}");

        }
    }
}
