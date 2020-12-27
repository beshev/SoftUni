using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            if (CheckFirstLineIsLonger(x1, y1, x2, y2) >= CheckSecondLineIsLonger(x3, y3, x4, y4))
            {
                GetPoitsPositionInFirstLine(x1, y1, x2, y2);
            }
            else
            {
                GetPoitsPositionInSecondLine(x3, y3, x4, y4);
            }
        }

        static double CheckFirstLineIsLonger(double x1, double y1, double x2, double y2)
        {
            double sum = Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2);
            return sum;
        }

        static double CheckSecondLineIsLonger(double x3, double y3, double x4, double y4)
        {
            double sum = Math.Abs(x3) + Math.Abs(y3) + Math.Abs(x4) + Math.Abs(y4);
            return sum;
        }

        static void GetPoitsPositionInFirstLine(double x1, double y1, double x2, double y2)
        {
            double x = 0;
            double y = 0;
            double X1 = 0;
            double Y1 = 0;
            if (Math.Abs(x1) + Math.Abs(y1) <= Math.Abs(x2) + Math.Abs(y2))
            {
                x = x1;
                y = y1;
                X1 = x2;
                Y1 = y2;
            }
            else
            {
                x = x2;
                y = y2;
                X1 = x1;
                Y1 = y1;
            }
            Console.WriteLine($"({x}, {y})({X1}, {Y1})");

        }

        static void GetPoitsPositionInSecondLine(double x3, double y3, double x4, double y4)
        {
            double x = 0;
            double y = 0;
            double X1 = 0;
            double Y1 = 0;
            if (Math.Abs(x3) + Math.Abs(y3) <= Math.Abs(x4) + Math.Abs(y4))
            {
                x = x3;
                y = y3;
                X1 = x4;
                Y1 = y4;
            }
            else
            {
                x = x4;
                y = y4;
                X1 = x3;
                Y1 = y3;
            }
            Console.WriteLine($"({x}, {y})({X1}, {Y1})");
        }
    }
}

