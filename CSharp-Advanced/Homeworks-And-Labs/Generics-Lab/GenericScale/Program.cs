using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> resut = new EqualityScale<int>(5, 5);
            Console.WriteLine(resut.AreEqual());
        }
    }
}
