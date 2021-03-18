using System;

namespace _04.FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result = 0;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Cannot convert int to byte");
            }
            Console.ReadLine();
        }
    }
}
