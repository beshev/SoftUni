using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakePieces = width * length;
            int piecesTake = 0;
            // Find pieces takes
            string input = Console.ReadLine();
            while (input != "STOP")
            {
                piecesTake += int.Parse(input);
                if (piecesTake > cakePieces)
                {
                    Console.WriteLine($"No more cake left! You need {piecesTake - cakePieces} pieces more.");
                    break;
                }
                input = Console.ReadLine();

            }
            if (input == "STOP")
            {
                Console.WriteLine($"{cakePieces - piecesTake} pieces are left.");
            }
        }
    }
}
