using System;

namespace _05._02.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int judges = int.Parse(Console.ReadLine());

            for (int i = 0; i < judges; i++)
            {
                string judgeName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());
                double allPoints = judgeName.Length * points / 2;
                pointsFromAcademy += allPoints;
                if (pointsFromAcademy > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {pointsFromAcademy:f1}!");
                    return;
                }
            }
            Console.WriteLine($"Sorry, {actorName} you need { 1250.5 - pointsFromAcademy:f1} more!");
        }
    }
}
