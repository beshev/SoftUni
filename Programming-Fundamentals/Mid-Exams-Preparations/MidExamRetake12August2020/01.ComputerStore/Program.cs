using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            decimal taxes = 0;
            decimal price = 0;
            string input = Console.ReadLine();
            while (input != "special" && input != "regular")
            {
                if (decimal.Parse(input) < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                price += decimal.Parse(input);
                taxes += decimal.Parse(input) * (decimal)0.2;
                input = Console.ReadLine();
            }
            decimal totaPrice = price + taxes;
            if (input == "special")
            {
                totaPrice -= totaPrice * (decimal)0.1;
            }
            if (totaPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {price:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totaPrice:f2}$");
            }
        }
    }
}
