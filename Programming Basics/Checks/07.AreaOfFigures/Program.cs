using System;
using System.Transactions;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            double sum = 0;  



            // Лице на Квадрат ;
            if (start == "square")
            {
                double  square = double.Parse(Console.ReadLine());
                sum = square * square;
            }
            // Лице на Правоъгълник;
            else if (start == "rectangle")
            {               
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                sum = l * w;
                
            }
            // Лице на Кръг; 
            else if (start == "circle")
            {
                double circle = double.Parse(Console.ReadLine());
                sum = Math.PI * (circle * circle);
                
            }
            // Лице на Триъгълник;
            else if (start == "triangle")
            {
                double l = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                sum = (l * h) / 2;
                

            }
            Console.WriteLine($"{sum:f3}");
        }
    }
}
