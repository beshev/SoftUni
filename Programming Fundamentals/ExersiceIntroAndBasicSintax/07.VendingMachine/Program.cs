using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {


            double totalSum = 0;
            string input = Console.ReadLine();
            while (input != "Start")
            {
                double money = double.Parse(input);
                bool avaibleMoney = money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2;
                if (avaibleMoney)
                {
                    totalSum += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }


                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                double priceProduct = 0;
                switch (input)
                {
                    case "Nuts":
                        priceProduct = 2.0;
                        if (totalSum >= priceProduct)
                        {
                            totalSum -= priceProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine($"Purchased {"nuts"}");
                        break;
                    case "Water":
                        priceProduct = 0.7;
                        if (totalSum >= priceProduct)
                        {
                            totalSum -= priceProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine($"Purchased {"water"}");
                        break;
                    case "Crisps":
                        priceProduct = 1.5;
                        if (totalSum >= priceProduct)
                        {
                            totalSum -= priceProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine($"Purchased {"crisps"}");
                        break;
                    case "Soda":
                        priceProduct = 0.8;
                        if (totalSum >= priceProduct)
                        {
                            totalSum -= priceProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine($"Purchased {"soda"}");
                        break;
                    case "Coke":
                        priceProduct = 1.0;
                        if (totalSum >= priceProduct)
                        {
                            totalSum -= priceProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine($"Purchased {"coke"}");
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }               
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
