using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string season = Console.ReadLine();
            string typeGroup = Console.ReadLine();
            int numKids = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double price = 0;
            string sport = "";

            // Find Price => Type of season , Type of group;
            // Find Type Of Sports => Season
            switch (season)
            {
                case "Winter":
                    switch (typeGroup)
                    {
                        case "mixed":
                            sport = "Ski";
                            price = nights * 10 * numKids;
                            break;
                        case "boys":
                            sport = "Judo";
                            price = nights * 9.60 * numKids;
                            break;
                        default:
                            sport = "Gymnastics";
                            price = nights * 9.60 * numKids;
                            break;
                    }
                    break;
                case "Spring":
                    switch (typeGroup)
                    {
                        case "mixed":
                            sport = "Cycling";
                            price = nights * 9.50 * numKids;
                            break;
                        case "boys":
                            sport = "Tennis";
                            price = nights * 7.20 * numKids;
                            break;
                        default:
                            sport = "Athletics";
                            price = nights * 7.20 * numKids;
                            break;
                    }
                    break;
                case "Summer":
                    switch (typeGroup)
                    {
                        case "mixed":
                            sport = "Swimming";
                            price = nights * 20 * numKids;
                            break;
                        case "boys":
                            sport = "Football";
                            price = nights * 15 * numKids;
                            break;
                        default:
                            sport = "Volleyball";
                            price = nights * 15 * numKids;
                            break;
                    }
                    break;
            }
            // Find Discounts 
            if (numKids >= 10 && numKids < 20)
            {
                price -= price * 0.05;
            }
            else if (numKids >= 20 && numKids < 50)
            {
                price -= price * 0.15;
            }
            else if( numKids >= 50)
            {
                price -= price * 0.50;
            }
            // Print Output
            Console.WriteLine($"{sport} {price:f2} lv.");

        }
    }
}
