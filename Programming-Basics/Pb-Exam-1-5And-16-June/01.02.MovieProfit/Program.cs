using System;

namespace _01._02.MovieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double priceTickets = double.Parse(Console.ReadLine());
            int percengate = int.Parse(Console.ReadLine());

            priceTickets *= tickets;
            priceTickets *= days;
            double percentages = percengate * 1.0 / 100;
            priceTickets -= priceTickets * percentages;
            Console.WriteLine($"The profit from the movie {movie} is {priceTickets:F2} lv.");


        }
    }
}
