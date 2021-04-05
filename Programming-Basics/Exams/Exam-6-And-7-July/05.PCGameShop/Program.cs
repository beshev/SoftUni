using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameSale = int.Parse(Console.ReadLine());
            int counterHearthstone = 0;
            int counterFornite = 0;
            int counterOverwach = 0;
            int counterOthers = 0;

            for (int i = 0; i < gameSale; i++)
            {
                string gameName = Console.ReadLine();
                switch (gameName)
                {
                    case "Hearthstone":
                        counterHearthstone++;
                        break;
                    case "Fornite":
                        counterFornite++;
                        break;
                    case "Overwatch":
                        counterOverwach++;
                        break;
                    default:
                        counterOthers++;
                        break;
                }

            }
            Console.WriteLine($"Hearthstone - {(double)counterHearthstone / gameSale * 100:F2}%");
            Console.WriteLine($"Fornite - {(double)counterFornite / gameSale * 100:F2}%");
            Console.WriteLine($"Overwatch - {(double)counterOverwach / gameSale * 100:f2}%");
            Console.WriteLine($"Others - {(double)counterOthers / gameSale * 100:F2}%");
        }
    }
}
