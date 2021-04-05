using System;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int sum = 0;

            switch (day)
            {
                case "Monday":
                    sum = 12;
                    break;
                case "Tuesday":
                    sum = 12;
                    break;
                case "Wednesday":
                    sum = 14;
                    break;
                case "Thursday":
                    sum = 14;
                    break;
                case "Friday":
                    sum = 12;
                    break;
                case "Saturday":
                    sum = 16;
                    break;
                case "Sunday":
                    sum = 16;
                    break;
            }
            Console.WriteLine(sum);
        }
    }
}
