using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            //Площа На Залата = (Дължината* 100) * (Широчината * 100);
            //Площа на Гардероба = (а * 100) * (а * 100);
            //Площа на Скамейката = Полща На Залата / 10;
            //Мястото за Танцьор = 40 + 7000;
            //Останало Място За Танцьори = (Площа На Залата - Площа На Гардероба - Площа На Скамейката) * (Място за Танцьор * 0.0001);

            double lenght = double.Parse(Console.ReadLine());
            double winght = double.Parse(Console.ReadLine());
            double aDrob = double.Parse(Console.ReadLine());

            double areaHall = (lenght * 100) * (winght * 100);
            double areaADrob = (aDrob * 100) * (aDrob * 100);
            double areaPench = areaHall / 10;
            double freeSpace = (areaHall - areaADrob - areaPench);
            double freeSpace2 = freeSpace / (40 + 7000);
            Console.WriteLine(Math.Floor(freeSpace2));



        }
    }
}
