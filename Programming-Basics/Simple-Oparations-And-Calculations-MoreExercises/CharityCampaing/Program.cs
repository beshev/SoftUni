using System;

namespace CharityCampaing
{
    class Program
    {
        static void Main(string[] args)
        {

            int numDays = int.Parse(Console.ReadLine());
            int numConf = int.Parse(Console.ReadLine());
            int numCakes = int.Parse(Console.ReadLine());
            int numWaff = int.Parse(Console.ReadLine());
            int numPancakes = int.Parse(Console.ReadLine());
            double priceCakes = numCakes * 45;
            double priceWaff = numWaff * 5.80;
            double pricePancakes = numPancakes * 3.20;
            double sumall = (priceCakes + priceWaff + pricePancakes) * numConf;
            double sumByDays = sumall * numDays;
            double sumOf18 = sumByDays * 1 / 8;
            double sumEnd = sumByDays - sumOf18;

            Console.WriteLine($"{sumEnd:f2}");

        }
    }
}
