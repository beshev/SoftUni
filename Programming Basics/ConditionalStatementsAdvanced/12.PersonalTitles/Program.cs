using System;

namespace _12.PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double years = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            string title = "";

            switch (gender)
            {
                case 'm':
                    if (years >= 16)
                    {
                        title = "Mr.";
                    }
                    else
                    {
                        title = "Master";
                    }
                    break;
                case 'f':
                    if (years >= 16)
                    {
                        title = "Ms.";
                    }
                    else
                    {
                        title = "Miss";
                    }
                    break;
            }
            Console.WriteLine(title);
        }
    }
}
