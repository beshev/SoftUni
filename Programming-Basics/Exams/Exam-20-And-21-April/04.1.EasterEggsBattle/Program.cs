using System;

namespace _04._1.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEgg1 = int.Parse(Console.ReadLine());
            int numEgg2 = int.Parse(Console.ReadLine());

            string winner = Console.ReadLine();
            while (winner != "End of battle")
            {
                if (winner == "one")
                {
                    numEgg2--;
                }
                else if (winner == "two")
                {
                    numEgg1--;
                }
                if (numEgg1 == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {numEgg2} eggs left.");
                    break;
                }
                else if (numEgg2 == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {numEgg1} eggs left.");
                    break;
                }
                                                                             
                winner = Console.ReadLine();
            }
            if (winner == "End of battle")
            {
                Console.WriteLine($"Player one has {numEgg1} eggs left.");
                Console.WriteLine($"Player two has {numEgg2} eggs left.");
            }
        }
    }
}
