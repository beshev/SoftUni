using System;

namespace _02.CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalk = int.Parse(Console.ReadLine());
            int numWalk = int.Parse(Console.ReadLine());
            int caloriForDay = int.Parse(Console.ReadLine());

            int caloriBurn = minutesWalk * 5;
            caloriBurn *= numWalk;
            double caloriOff = caloriForDay - (caloriForDay * 0.5);

            if (caloriBurn >= caloriOff)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriBurn}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriBurn}.");
            }
        }
    }
}
