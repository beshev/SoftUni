using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            GetPriceOfOrderTypeAndQuantity(type, quantity);
        }

        static void GetPriceOfOrderTypeAndQuantity(string type, int quantity)
        {
            double sum = 0;
            switch (type)
            {
                case "coffee":
                    sum = quantity * 1.50;
                    break;
                case "water":
                    sum = quantity * 1.00;
                    break;
                case "coke":
                    sum = quantity * 1.40;
                    break;
                case "snacks":
                    sum = quantity * 2.00;
                    break;
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
