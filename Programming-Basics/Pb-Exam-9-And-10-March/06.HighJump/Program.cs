using System;

namespace _06.HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int start = target - 30;
            int counterFail = 0;
            int counterJumps = 0;

            while (true)
            {
                int jumup = int.Parse(Console.ReadLine());
                counterJumps++;
                if (jumup <= start)
                {
                    counterFail++;                   
                    if (counterFail == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {start}cm after {counterJumps} jumps.");
                        return;
                    }             
                }   
                else
                {
                    counterFail = 0;
                    start += 5;
                }
                if (start > target)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {start - 5}cm after {counterJumps} jumps.");
                    return;
                }


            }
        }
    }
}
