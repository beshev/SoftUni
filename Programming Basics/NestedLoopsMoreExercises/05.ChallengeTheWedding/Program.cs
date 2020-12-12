using System;

namespace _05.ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input : 
            int numMen = int.Parse(Console.ReadLine());
            int numWomen = int.Parse(Console.ReadLine());
            int numTable = int.Parse(Console.ReadLine());
            int counterDate = 0;

            for (int men = 1; men <= numMen; men++)
            {
                for (int womens = 1; womens <= numWomen; womens++)
                {

                    Console.Write($"({men} <-> {womens}) ");
                    counterDate++;
                    // if table ends ->
                    if (counterDate == numTable)
                    {                        
                        return;
                    }


                }
            }
        }
    }
}
