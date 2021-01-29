using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        public static object StopWatch { get; private set; }

        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();
            string guest = Console.ReadLine();
            while (guest != "PARTY")
            {
                if (guest.Length == 8 && (guest[0] >= 48 && guest[0] <= 57))
                {
                    vip.Add(guest);
                }
                else if (guest.Length == 8)
                {
                    regular.Add(guest);
                }
                guest = Console.ReadLine();
            }
            guest = Console.ReadLine();
            while (guest != "END")
            {
                if (regular.Contains(guest))
                {
                    regular.Remove(guest);
                }
                if (vip.Contains(guest))
                {
                    vip.Remove(guest);
                }
                guest = Console.ReadLine();
            }
            Console.WriteLine(vip.Count + regular.Count);
            vip.ToList().ForEach(x => Console.WriteLine(x));
            regular.ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
