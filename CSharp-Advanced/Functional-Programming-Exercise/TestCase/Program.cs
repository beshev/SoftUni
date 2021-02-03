using System;

namespace _11___The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetFactorial(1, 3, 0));
        }

        static int GetFactorial(int start, int end, int sum)
        {
            sum += start;
            start++;
            if (start <= end)
            {
                sum += GetFactorial(start, end, sum);
            }
            return sum;
        }
    }
}