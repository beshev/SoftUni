using System;

namespace _05.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeed = int.Parse(Console.ReadLine());
            int dayHave = int.Parse(Console.ReadLine());
            int workAdd= int.Parse(Console.ReadLine());
            double daysWork = dayHave - (dayHave * 0.10);
            double hoursWork =daysWork * 8;
            double hoursAdd = dayHave * (workAdd * 2) ;
            double hoursLeft = Math.Floor(hoursWork + hoursAdd);
            if (hoursNeed <= hoursLeft)
            {
                Console.WriteLine($"Yes!{hoursLeft - hoursNeed} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeed - hoursLeft} hours needed.");
            }

            



        }
    }
}
