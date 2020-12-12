using System;
using System.Xml;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double sum = (a * h / 2);

            Console.WriteLine($"{sum:f2}");
        }
    }
}
