using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            char lastSector = char.Parse(Console.ReadLine());
            int numsSector = int.Parse(Console.ReadLine());
            int numsOdd = int.Parse(Console.ReadLine());
            int counterEven = 0;
            // Find Sectors
            for (char sectorOne = 'A'; sectorOne <= lastSector; sectorOne++)
            {
                // Find Number of Sectors:
                for (int sectorNum = 1; sectorNum <= numsSector; sectorNum++)
                {
                    if (sectorNum % 2 == 0)
                    {
                        numsOdd += 2;
                    }
                    // Find Line Char
                    for (char lineletter = 'a'; lineletter < 'a' + numsOdd; lineletter++)
                    {
                        if (sectorNum % 2 == 0)
                        {
                            Console.WriteLine($"{sectorOne}{sectorNum}{lineletter}");
                        }
                        else
                        {
                            Console.WriteLine($"{sectorOne}{sectorNum}{lineletter}");
                        }
                        counterEven++;
                    }
                    if (sectorNum % 2 == 0)
                    {
                        numsOdd -= 2;
                    }


                }
                // after Sector 'A' numsSector -> +1;
                numsSector++;
            }
            Console.Write(counterEven);
        }
    }
}
