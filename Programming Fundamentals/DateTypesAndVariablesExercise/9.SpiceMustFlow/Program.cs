using System;

namespace _9.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint startYield = uint.Parse(Console.ReadLine());
            int counterDays = 0;
            int spiceExtract = 0;
            while (startYield >= 100)
            {
                counterDays++;
                spiceExtract += (int)startYield - 26;
                startYield -= 10;
            }
            if (spiceExtract >= 26)
            {
                spiceExtract -= 26;
            }
            Console.WriteLine($"{counterDays}");
            Console.WriteLine($"{spiceExtract}");
        }
    }
}
