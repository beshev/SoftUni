using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondSecond = Console.ReadLine();
            DateModifier difference = new DateModifier();
            difference.Difference = difference.GetDayBetweenTwoDates(firstDate,secondSecond);
            Console.WriteLine(difference.Difference);
        }
    }
}
