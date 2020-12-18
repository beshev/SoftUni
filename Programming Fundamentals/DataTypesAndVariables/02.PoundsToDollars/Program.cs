using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public static class Program
    {
        public static void Main()
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal usd = pounds * 1.31m;
            Console.WriteLine($"{usd:f3}");

        }
    }
}