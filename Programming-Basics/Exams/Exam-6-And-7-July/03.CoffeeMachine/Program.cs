using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string shugar = Console.ReadLine();
            int numBuy = int.Parse(Console.ReadLine());
            double sum = 0;

            switch (name)
            {
                case "Espresso":
                    switch (shugar)
                    {
                        case "Without":
                            sum = 0.90;
                            break;
                        case "Normal":
                            sum = 1;
                            break;
                        case "Extra":
                            sum = 1.20;
                            break;
                    }
                    break;
                case "Cappuccino":
                    switch (shugar)
                    {
                        case "Without":
                            sum = 1;
                            break;
                        case "Normal":
                            sum = 1.20;
                            break;
                        case "Extra":
                            sum = 1.60;
                            break;
                    }
                    break;
                case "Tea":
                    switch (shugar)
                    {
                        case "Without":
                            sum = 0.50;
                            break;
                        case "Normal":
                            sum = 0.60;
                            break;
                        case "Extra":
                            sum = 0.70;
                            break;
                    }
                    break;
            }
            sum *= numBuy;
            if (shugar == "Without")
            {
                sum -= sum * 0.35;
            }
            if (name == "Espresso" && numBuy >= 5)
            {
                sum -= sum * 0.25;
            }
            if (sum > 15)
            {
                sum -= sum * 0.2;
            }
            Console.WriteLine($"You bought {numBuy} cups of {name} for {sum:f2} lv.");
        }
    }
}
