using System;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            string[] dungeons = Console.ReadLine().Split('|').ToArray();
            int health = 100;
            int bitcoins = 0;
            for (int i = 0; i < dungeons.Length; i++)
            {
                string[] command = dungeons[i].Split();
                if (command[0] == "potion")
                {
                    AddAndPrintCurrentHealt(int.Parse(command[1]), ref health);
                }
                else if (command[0] == "chest")
                {
                    AddBitcoins(int.Parse(command[1]), ref bitcoins);
                }
                else
                {
                    PrintResultAfterFight(command[0], int.Parse(command[1]), ref health);
                    if (health <= 0)
                    {
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }

        static void AddAndPrintCurrentHealt(int healtAdd, ref int currentHealt)
        {
            if (currentHealt + healtAdd > 100)
            {
                healtAdd = healtAdd - ((currentHealt + healtAdd) - 100);
                currentHealt = 100;
            }
            else
            {
                currentHealt += healtAdd;
            }
            Console.WriteLine($"You healed for {healtAdd} hp.");
            Console.WriteLine($"Current health: {currentHealt} hp.");
        }

        static void AddBitcoins(int bitcoins, ref int currentBitcoins)
        {
            currentBitcoins += bitcoins;
            Console.WriteLine($"You found {bitcoins} bitcoins.");
        }

        static void PrintResultAfterFight(string monster, int monsterAttack, ref int healt)
        {
            if (healt - monsterAttack <= 0)
            {
                healt = 0;
                Console.WriteLine($"You died! Killed by {monster}.");
            }
            else
            {
                healt -= monsterAttack;
                Console.WriteLine($"You slayed { monster}.");
            }
        }

    }
}
