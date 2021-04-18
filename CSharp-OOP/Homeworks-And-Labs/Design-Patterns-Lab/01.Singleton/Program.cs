using _01.Singleton.Models;
using DesignPatternsLab.Models.Contracts;
using System;

namespace DesignPatternsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            ISingletonContainer db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulaton("Sofia"));
            ISingletonContainer db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulaton("London"));
        }
    }
}
