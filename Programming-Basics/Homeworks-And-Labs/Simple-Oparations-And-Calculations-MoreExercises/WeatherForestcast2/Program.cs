using System;

namespace IfOrElse
{
    class Program
    {
        static void Main(string[] args)
        {
            double hot = double.Parse(Console.ReadLine());


            if (hot >= 26 & hot <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if (hot >= 20.1 & hot <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (hot >= 15.00 & hot <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            else if (hot >= 12.00 & hot <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (hot >= 5.00 & hot <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
