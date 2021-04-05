using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._3._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalSum = 0;
            string pattern = @"%(?<name>[A-Z][a-z]+)%.*<(?<product>\w+)>.*\|(?<count>[0-9]+)\|";
            string input = Console.ReadLine();
            while (input != "end of shift")
            {
                Match nameProductCount = Regex.Match(input,pattern);
                if (nameProductCount.Value.Length > 0)
                {
                    string name = nameProductCount.Groups["name"].ToString();
                    string product = nameProductCount.Groups["product"].ToString();
                    int count = int.Parse(nameProductCount.Groups["count"].ToString());
                    Match marchForPrice = Regex.Match(input, @"([0-9]+[.]?[0-9]+)\$");
                    if (marchForPrice.Value.Length > 0)
                    {
                        decimal price = decimal.Parse(marchForPrice.Groups[1].ToString());
                        Console.WriteLine($"{name}: {product} - {count * price:f2}");
                        totalSum += count * price;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
