using System;

namespace _10.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string evaluation = Console.ReadLine();
            double nights = days - 1;
            double price = 0;
            double discount = 0;

            // Find Price For Room And Discount
            switch (room)
            {
                case "room for one person":
                    price = nights * 18;
                    break;
                case "apartment":
                    price = nights * 25;
                    if (nights < 10)
                    {
                        discount = price * 0.3;
                        price -= discount;
                    }
                    else if (days >= 10 &&  days <= 15)
                    {
                        discount = price * 0.35;
                        price -= discount;
                    }
                    else
                    {
                        discount = price * 0.5;
                        price -= discount; 
                    }
                    break;
                case"president apartment":
                    price = nights * 35;
                    if (nights < 10)
                    {
                        discount = price * 0.1;
                        price -= discount;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = price * 0.15;
                        price -= discount;
                    }
                    else
                    {
                        discount = price * 0.2;
                        price -= discount;
                    }
                    break;
            }


            // Find Price aftre evaluation
            if (evaluation == "positive")
            {
                discount = price * 0.25;
                price += discount;
            }
            else
            {
                discount = price * 0.1;
                price -= discount;
            }

            // Print Output
            Console.WriteLine($"{price:f2}");
        }
    }
}
