using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int poweredNum = int.Parse(Console.ReadLine());
            Console.WriteLine(RiseToPower(number, poweredNum));
        }

        static double RiseToPower(double number, int powered)
        {
            double sum = 1;
            for (int i = 0; i < powered; i++)
            {
                sum *= number;
            }
            return sum;
        }
    }
}
