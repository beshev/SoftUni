using System;

namespace _02.EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGuests = int.Parse(Console.ReadLine());
            int moneyHave = int.Parse(Console.ReadLine());

            double numEgg = numGuests * 2;
            double sumEgg = numEgg * 0.45;
            double numEasterBread = Math.Ceiling((numGuests * 1.0) / 3);
            double sumBread = numEasterBread * 4;

            double totalSum = sumBread + sumEgg;
            if (moneyHave >= totalSum)
            {
                Console.WriteLine($"Lyubo bought {numEasterBread} Easter bread and {numEgg} eggs.");
                Console.WriteLine($"He has {moneyHave - totalSum:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalSum - moneyHave:f2} lv. more.");
            }




        }
    }
}
