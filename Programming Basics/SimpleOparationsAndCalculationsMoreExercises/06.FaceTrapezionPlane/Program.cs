using System;
using System.ComponentModel.DataAnnotations;

namespace _06.FaceTrapezionPlane
{
    class Program
    {
        static void Main(string[] args)
        {
           
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double lenght = Math.Abs(x1 - x2);
            double windth = Math.Abs(y1 - y2);
            double area = lenght * windth;
            double perimeter = 2 * (lenght + windth);
            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{perimeter:f2}");



        }
    }
}
