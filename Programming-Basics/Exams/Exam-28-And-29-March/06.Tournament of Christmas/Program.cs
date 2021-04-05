using System;

namespace _06.Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            int totalWin = 0;
            int totalLose = 0;

            for (int i = 0; i < days; i++)
            {
                int counterWin = 0;
                int counterLose = 0;
                double money = 0;
                string input = Console.ReadLine();
                while (input != "Finish")
                {
                    string end = Console.ReadLine();
                    if (end == "win")
                    {
                        money += 20;
                        counterWin++;
                        totalWin++;
                    }
                    else if (end == "lose")
                    {
                        counterLose++;
                        totalLose++;
                    }
                    input = Console.ReadLine();
                }
                if (counterWin > counterLose)
                {
                    money += (money * 0.1);
                }
                totalMoney += money;

            }
            if (totalWin > totalLose)
            {
                totalMoney += (totalMoney * 0.2);
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else if (totalLose > totalWin)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
