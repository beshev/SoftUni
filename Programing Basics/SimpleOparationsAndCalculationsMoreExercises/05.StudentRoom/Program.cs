using System;

namespace _05.StudentRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double h1 = h * 100 - 100;
            double w1 = w * 100;
            double h2 = Math.Floor (h1 / 70);
            double w2 = Math.Floor (w1 / 120);
            double sumAll = ( h2 * w2 ) - 3;
            Console.WriteLine(sumAll);













        }
    }
}
