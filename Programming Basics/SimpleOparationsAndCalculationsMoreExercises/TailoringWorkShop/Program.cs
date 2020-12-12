using System;

namespace TailoringWorkShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Полща на Покривките = БрояНаМасите * ( Широчината + (2*0,30) * Дължината + (2*0,30) );
            // Площа На Каретата = БрояНаМасите * (Дължината / 2 * Дължината / 2);
            // Цена В Долари = Площа * 7 + Каретата + 9; 
            // Цена В Лева = Долари * 1,85;

            int numbOfTable = int.Parse(Console.ReadLine());
            double lenghtOfTable = double.Parse(Console.ReadLine());
            double widthOfTable = double.Parse(Console.ReadLine());
            double areaOfPlat = numbOfTable * (lenghtOfTable + (2 * 0.30)) * (widthOfTable + (2 * 0.30));
            double areaOfCare = numbOfTable * (lenghtOfTable / 2) * (lenghtOfTable / 2);
            double priceOfUSD = areaOfPlat * 7 + areaOfCare * 9;
            double priceOfBGN = priceOfUSD * 1.85;

            Console.WriteLine($"{priceOfUSD:f2} USD");
            Console.WriteLine($"{priceOfBGN:f2} BGN");






        }
    }
}
