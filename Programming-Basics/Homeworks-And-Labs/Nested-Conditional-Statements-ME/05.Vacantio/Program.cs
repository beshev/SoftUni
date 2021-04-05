using System;

namespace _05.Vacantio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            double money = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            string type = "";
            string locatio = "";

            // Find Price , Type Acc... and Locatoi
            if (money <= 1000)
            {
                type = "Camp";
                if ( season == "Summer")
                {
                    locatio = "Alaska";
                    price = money * 0.65;
                }
                else
                {
                    locatio = "Morocco";
                    price = money * 0.45;
                }
            }
            else if (money <= 3000)
            {
                type = "Hut";
                if (season == "Summer")
                {
                    locatio = "Alaska";
                    price = money * 0.80;
                }
                else
                {
                    locatio = "Morocco";
                    price = money * 0.60;
                }
            }
            else
            {
                type = "Hotel";
                price = money * 0.90;
                    if (season == "Summer")
                {
                    locatio = "Alaska";                  
                }
                else
                {
                    locatio = "Morocco";
                }
            }
            // Print Output
            Console.WriteLine($"{locatio} - {type} - {price:f2}");
        }
    }
}
