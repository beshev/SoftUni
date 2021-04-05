using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            MatchCollection matches = Regex.Matches(someText, @"(\||#)([A-Za-z ]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d+)\1");
            List<Product> products = new List<Product>();
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                string foodName = match.Groups[2].Value;
                string expireDate = match.Groups[3].Value;
                int calories = int.Parse(match.Groups[4].Value);
                totalCalories += calories;
                Product currentProduct = new Product(foodName,expireDate,calories);
                products.Add(currentProduct);
            }
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            products.ForEach(x => Console.WriteLine(x));

        }
    }

    class Product
    {
        public string Name { get; set; }

        public string ExpirationDate { get; set; }

        public int Calories { get; set; }

        public Product(string name, string expirationDate, int calories)
        {
            this.Name = name;
            this.ExpirationDate = expirationDate;
            this.Calories = calories;
        }

        public override string ToString()
        {
            return $"Item: {Name}, Best before: {ExpirationDate}, Nutrition: {Calories}";
        }
    }
}
