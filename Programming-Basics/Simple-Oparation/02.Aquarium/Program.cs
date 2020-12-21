using System;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            int wid = int.Parse(Console.ReadLine());
            int hei = int.Parse(Console.ReadLine());
            double per = double.Parse(Console.ReadLine());
            double vol = len * wid * hei;
            double lit = vol * 0.001;
            double per2 = per * 0.01;
            double sum = lit * (1 - per2);

            Console.WriteLine($"{sum:f3}");



        }
    }
}
