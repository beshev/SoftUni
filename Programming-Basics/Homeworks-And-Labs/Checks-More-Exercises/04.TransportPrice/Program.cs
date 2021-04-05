using System;

namespace _04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKil = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            double price = 0;
            double numKil1 = numKil * 1.0;
            if (numKil < 20 & type == "day")
            {
                // Taxi
                price = numKil1 * 0.79 + 0.70;
            }
            else if (numKil < 20 & type == "night")
            {
                price = numKil * 0.90 + 0.70;
            }
            else if (numKil < 100)
            {                
                price = numKil * 0.09;
            }
            else
            {               
                price = numKil * 0.06;
            }
            Console.WriteLine($"{price:f2}");

        }
    }
}
