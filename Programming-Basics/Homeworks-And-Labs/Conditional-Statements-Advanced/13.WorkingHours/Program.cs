using System;

namespace _13.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string end = "";

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    if (hour >= 10 && hour <= 18)
                    {
                        end = "open";
                    }
                    else
                    {
                        end = "closed";
                    }
                    break;
                case "Sunday":
                    end = "closed";
                    break;
            }
            Console.WriteLine(end);
        }
    }
}
