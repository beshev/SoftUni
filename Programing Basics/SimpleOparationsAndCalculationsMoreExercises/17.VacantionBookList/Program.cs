using System;

namespace _17.VacantionBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            int numsPages = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int dayForRead = int.Parse(Console.ReadLine());
            double sum = 0;
            sum = (numsPages * 1.0) / pagesForHour;
            sum /= dayForRead;


                Console.WriteLine(sum);
        }
    }
}
