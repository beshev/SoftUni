using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int loseGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashHeadsed = 0;
            int trashMouse = 0;
            int trashKeyboard = 0;
            int trashDisplay = 0;
            for (int i = 1; i <= loseGames; i++)
            {
                if (i % 2 == 0)
                {
                    trashHeadsed++;
                }
                if (i % 3 == 0)
                {
                    trashMouse++;
                }
                if (i % 6 == 0)
                {
                    trashKeyboard++;
                    if (trashKeyboard % 2 == 0)
                    {
                        trashDisplay++;
                    }
                }
            }
            double totalSum = trashHeadsed * headsetPrice;
            totalSum += trashMouse * mousePrice;
            totalSum += trashKeyboard * keyboardPrice;
            totalSum += trashDisplay * displayPrice;
            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");

        }
    }
}
