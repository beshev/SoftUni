using System;

namespace _03._02.TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            string typePackage = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double sum = 0;
            bool point1 = townName != "Bansko" && townName != "Borovets" && townName != "Varna" && townName != "Burgas";
            bool point2 = typePackage != "withEquipment" && typePackage != "noEquipment" && typePackage != "withBreakfast" && typePackage != "noBreakfast";
            if (days < 1)
            {
                Console.WriteLine($"Days must be positive number!");
                return;
            }
            else if (point1 || point2)
            {
                Console.WriteLine($"Invalid input!");
                return;
            }

            switch (townName)
            {
                case "Bansko":
                case "Borovets":
                    switch (typePackage)
                    {
                        case "withEquipment":
                            sum = 100;
                            if (vip == "yes")
                            {
                                sum -= sum * 0.1;
                            }
                            break;
                        case "noEquipment":
                            sum = 80;
                            if (vip == "yes")
                            {
                                sum -= sum * 0.05;
                            }
                            break;
                    }
                    break;
                case "Varna":
                case "Burgas":
                    switch (typePackage)
                    {
                        case "withBreakfast":
                            sum = 130;
                            if (vip == "yes")
                            {
                                sum -= sum * 0.12;
                            }
                            break;
                        case "noBreakfast":
                            sum = 100;
                            if (vip == "yes")
                            {
                                sum -= sum * 0.07;
                            }
                            break;
                    }
                    break;
            }
            if (days > 7)
            {
                days -= 1;
            }
            sum *= days;
            Console.WriteLine($"The price is {sum:f2}lv! Have a nice time!");



        }
    }
}
