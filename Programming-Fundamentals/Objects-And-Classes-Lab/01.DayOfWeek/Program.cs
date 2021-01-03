using System;
using System.Globalization;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DateTime day = DateTime.ParseExact(input,"d-MM-yyyy" ,CultureInfo.InvariantCulture);
            Console.WriteLine(day.DayOfWeek);
        }
    }
}
