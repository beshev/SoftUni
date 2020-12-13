using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBitcoin = int.Parse(Console.ReadLine());
            double yoan = double.Parse(Console.ReadLine());
            double change = double.Parse(Console.ReadLine());

            double leva = numBitcoin * 1168.0;
            double euro = leva / 1.95;
            double dolars = yoan * 0.15;
            dolars *= 1.76;
            dolars /= 1.95;
            double totalSum = dolars + euro;
            change /= 100;
            totalSum -= (totalSum * change);

            Console.WriteLine($"{totalSum:f2}");

        }
    }
}
