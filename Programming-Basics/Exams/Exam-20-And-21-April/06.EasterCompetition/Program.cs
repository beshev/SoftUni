using System;

namespace _06.EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int bread = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            string nameBaker = "";

            while (bread != 0)
            {
                int point = 0;
                string bakerName = Console.ReadLine();
                string bakerPoints = Console.ReadLine();
                while (bakerPoints != "Stop")
                {
                    int evaluation = int.Parse(bakerPoints);
                    point += evaluation;                    
                    bakerPoints = Console.ReadLine();

                }
                Console.WriteLine($"{bakerName} has {point} points.");
                if (point > totalPoints)
                {
                    totalPoints = point;
                    nameBaker = bakerName;
                    Console.WriteLine($"{nameBaker} is the new number 1!");
                }
                bread--;


            }
            Console.WriteLine($"{nameBaker} won competition with {totalPoints} points!");
        }
    }
}
