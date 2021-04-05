using System;

namespace LandscapingOfYards
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double price = meters * 7.61;
            double discount = 0.18 * price; 
            double sumEnd = price - discount;
            Console.WriteLine($"The final price is: {sumEnd:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
                
        }
    }
}
