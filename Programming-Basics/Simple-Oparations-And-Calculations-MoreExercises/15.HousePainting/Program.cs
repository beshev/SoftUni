using System;

namespace _15.HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            

            // Предната и задната стена са квадрати със страна „x“
              // = на предната стена има правоъгълна врата с широчина 1.2м и височина 2м
            double frontBackWall = ((x * x) - (1.2 * 2)) + (x * x);

            //	Страничните стени са правоъгълници със страни „x“ и „y“
            // = и на двете странични стени има по един квадратен прозорец със страна 1.5м
            double sideWalls = ((x * y) * 2) - ((1.5 * 1.5) * 2);
            double allSideWalls = (frontBackWall + sideWalls) / 3.4; 


            // Покривът има следните размери:
            // =	Два правоъгълника със страни „x“ и „y“
            double roofRectangle = (x * y) * 2;
            // =	Два равностранни триъгълника със страна „x“ и височина „h“
            double roofTriangle = (x * h) ;
            double allRoof = (roofRectangle + roofTriangle) / 4.3;

            Console.WriteLine($"{allSideWalls:f2}");
            Console.WriteLine($"{allRoof:f2}");

        }
    }
}
