using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = int.Parse(Console.ReadLine());
            double height = int.Parse(Console.ReadLine());
            double area = GetRectangleArea(width , height);
            Console.WriteLine(area);
        }

        static double GetRectangleArea(double width, double height) 
        {
            return width * height;
        }
    }
}
