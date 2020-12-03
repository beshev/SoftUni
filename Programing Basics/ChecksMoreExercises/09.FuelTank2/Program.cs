using System;

namespace _09.FuelTank2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read Input
            string type  = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();
            double price = 0;

            // Find Price For Gasoline => Type Of gas, quantity gas
            // Find Discount 
            switch (type)
            {
                case "Gas":
                    price = quantity *  0.93;
                    switch (card)
                    {
                        case "Yes":
                            price -= quantity * 0.08; 
                            break;
                    }
                    break;
                case "Gasoline":
                    price = quantity * 2.22;
                    switch (card)
                    {
                        case "Yes":
                            price -= quantity * 0.18;
                            break;
                    }
                    break;
                case "Diesel":
                    price = quantity * 2.33;
                    switch (card)
                    {
                        case "Yes":
                            price -= quantity * 0.12;
                            break;
                    }
                    break;
            }
            if (quantity > 20 && quantity <= 25)
            {
                price -= price * 0.08;
            }
            else if (quantity > 25)
            {
                price -= price * 0.10;
            }
            // Print Output
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
