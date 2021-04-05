using System;

namespace _08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string gasName = Console.ReadLine();
            double numGas = double.Parse(Console.ReadLine());
            if (numGas >= 25)
            {
                if (gasName == "Diesel")
                {
                    Console.WriteLine($"You have enough diesel.");
                }
                else if (gasName == "Gasoline")
                {
                    Console.WriteLine($"You have enough gasoline.");
                }
                else if (gasName == "Gas")
                {
                    Console.WriteLine($"You have enough gas.");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
            if (numGas < 25)
            {
                if (gasName == "Diesel")
                {
                    Console.WriteLine($"Fill your tank with diesel!");
                }
                else if (gasName == "Gasoline")
                {
                    Console.WriteLine($"Fill your tank with gasoline!");
                }
                else if (gasName == "Gas")
                {
                    Console.WriteLine($"Fill your tank with gas!");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
        }
    }
}
