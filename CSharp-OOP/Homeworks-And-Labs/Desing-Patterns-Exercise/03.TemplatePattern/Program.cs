using _03.TemplatePattern.Models;
using System;

namespace _03.TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Bread sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            Bread twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();

            Bread wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
