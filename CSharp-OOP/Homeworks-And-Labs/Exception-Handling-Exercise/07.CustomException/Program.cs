using System;

namespace _07.CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student goshko = new Student("Gin4o","DabiDabi@mail.bg");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
        }
    }
}
