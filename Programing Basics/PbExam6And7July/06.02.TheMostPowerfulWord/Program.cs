using System;

namespace _06._02.TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double winner = int.MinValue;
            string nameWinner = "";
            while (input != "End of words")
            {
                double sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    sum += (int)input[i];

                }
                bool a1 = input[0] == 'a' || input[0] == 'e' || input[0] == 'i' || input[0] == 'u' || input[0] == 'y' || input[0] == 'o';
                bool a2 = input[0] == 'A' || input[0] == 'E' || input[0] == 'I' || input[0] == 'U' || input[0] == 'Y' || input[0] == 'O';
                if (a1 || a2)
                {
                    sum *= input.Length;
                }
                else
                {
                    Math.Floor(sum /= input.Length);
                }
                if (sum > winner)
                {
                    winner = sum;
                    nameWinner = input;
                }



                input = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {nameWinner} - {winner}");
        }
    }
}
