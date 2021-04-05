using System;

namespace _08.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceHollyDay = double.Parse(Console.ReadLine());
            int numPuzzle = int.Parse(Console.ReadLine());
            int numDoll = int.Parse(Console.ReadLine());
            int numTeddyBear = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTruck = int.Parse(Console.ReadLine());
            double sumAll = 0;

            //Да се напише програма, която пресмята печалбата от поръчката.
            double priceToys = (numPuzzle * 2.60) + (numDoll * 3) + (numTeddyBear * 4.10) + (numMinions * 8.20) + (numTruck * 2);
          //  Ако поръчаните играчки са 50 или повече магазинът прави отстъпка 25 % от общата цена.
            double numToys = numPuzzle + numDoll + numTeddyBear + numMinions + numTruck;
            if (numToys >= 50)
            {
                priceToys = priceToys - (0.25 * priceToys);
                sumAll = priceToys - (0.10 * priceToys);

            }
            else
            {
                sumAll = priceToys - (0.10 * priceToys);
            }
            // Да се пресметне дали парите ще ѝ стигнат да отиде на екскурзия.
            if (sumAll >= priceHollyDay)
            {
                
                Console.WriteLine($"Yes! {Math.Abs(sumAll - priceHollyDay):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(sumAll - priceHollyDay):f2} lv needed.");
            }


        }
    }
}
