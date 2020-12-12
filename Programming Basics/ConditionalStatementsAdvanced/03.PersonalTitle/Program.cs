using System;

namespace _03.PersonalTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            double years = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            switch (gender)
            {
                case 'm':
                    if ( years >= 16)
                    {
                        Console.WriteLine("Mr.");
                    }
                    else
                    {
                        Console.WriteLine("Master");
                    }
                    break;
                    case 'f':
                    if (years >= 16)
                    {
                        Console.WriteLine("Ms.");
                    }
                    else
                    {
                        Console.WriteLine("Miss");
                    }
                    break;
            }


        }
    }
}
