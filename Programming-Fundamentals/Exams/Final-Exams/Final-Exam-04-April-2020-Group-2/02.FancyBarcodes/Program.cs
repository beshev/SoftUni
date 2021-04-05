using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                Match barcode = Regex.Match(command, @"@#+([A-Z][a-zA-Z0-9]{4,}[A-Z])@#+");
                if (barcode.Success)
                {
                    string productGropu = "00";
                    MatchCollection digits = Regex.Matches(barcode.Value, @"\d");
                    if (digits.Count > 0)
                    {
                        StringBuilder result = new StringBuilder();
                        foreach (var digit in digits)
                        {
                            result.Append(digit);
                        }
                        productGropu = result.ToString();
                    }
                    Console.WriteLine($"Product group: {productGropu}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
