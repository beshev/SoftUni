using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input ;
            int numCargo = int.Parse(Console.ReadLine());
            double priceBus = 0;
            double priceTruck = 0;
            double priceTrain = 0;
            double busTonnage = 0;
            double truckTonnage = 0;
            double trainTonnage = 0;
            double tonnagePrice = 0;

            // Find Price for  Each Cargo
            for (int i = 0; i < numCargo; i++)
            {
                int cargoTonnage = int.Parse(Console.ReadLine());
               tonnagePrice += cargoTonnage;
                if (cargoTonnage <= 3)
                {
                    priceBus += cargoTonnage * 200;
                    busTonnage += cargoTonnage;
                }
                else if (cargoTonnage >= 4 && cargoTonnage <= 11)
                {
                    priceTruck += cargoTonnage * 175;
                    truckTonnage += cargoTonnage;
                }
                else
                {
                    priceTrain += cargoTonnage * 120;
                    trainTonnage += cargoTonnage;
                }
            }
            // Find Average Price
            double tonnagePrice1 = (priceBus + priceTrain + priceTruck) / tonnagePrice;
            busTonnage = (busTonnage/ tonnagePrice) * 100;
            truckTonnage =  (truckTonnage / tonnagePrice) * 100;
            trainTonnage = (trainTonnage/ tonnagePrice) * 100;
            // Print Output
            Console.WriteLine($"{tonnagePrice1:f2}");
            Console.WriteLine($"{busTonnage:F2}%");
            Console.WriteLine($"{truckTonnage:f2}%");
            Console.WriteLine($"{trainTonnage:f2}%");

        }
    }
}
