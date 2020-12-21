using System;

namespace FromInchesToCentimetar
{
    class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());
            double cente = inch * 2.54;
            Console.WriteLine(cente);
        }
    }
}
