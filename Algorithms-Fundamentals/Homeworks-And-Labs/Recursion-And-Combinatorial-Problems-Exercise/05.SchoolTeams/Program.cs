using System;

namespace _05.SchoolTeams
{
    internal class Program
    {
        private static string[] girls;
        private static string[] boys;

        private static readonly string[] girlsCombinations = new string[3];
        private static readonly string[] boysCombinations = new string[2];

        static void Main(string[] args)
        {
            girls = Console.ReadLine().Split(", ");
            boys = Console.ReadLine().Split(", ");

            GirlsWithBoysCombinations();
        }


        static void BoysCombinations(int index = 0, int start = 0, string girlsAsString = "")
        {
            if (index >= boysCombinations.Length)
            {
                var boysAsString = string.Join(", ", boysCombinations);

                Console.WriteLine(girlsAsString + ", " + boysAsString);

                return;
            }


            for (int i = start; i < boys.Length; i++)
            {
                boysCombinations[index] = boys[i];
                BoysCombinations(index + 1, i + 1, girlsAsString);
            }
        }

        static void GirlsWithBoysCombinations(int index = 0, int start = 0)
        {
            if (index >= girlsCombinations.Length)
            {
                var girlsAsString = string.Join(", ", girlsCombinations);
                BoysCombinations(girlsAsString: girlsAsString);
                return;
            }


            for (int i = start; i < girls.Length; i++)
            {
                girlsCombinations[index] = girls[i];
                GirlsWithBoysCombinations(index + 1, i + 1);
            }
        }
    }
}
