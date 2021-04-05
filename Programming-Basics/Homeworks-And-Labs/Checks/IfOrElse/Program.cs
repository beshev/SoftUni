using System;

namespace IfOrElse
{
    class Program
    {
        static void Main(string[] args)
        {
            double evaluation = double.Parse(Console.ReadLine());

            if (evaluation >= 5.50 & evaluation <= 6) 
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
