using System;

namespace _05.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Convert.ToDouble("Testing try catch on ToDouble Method");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
