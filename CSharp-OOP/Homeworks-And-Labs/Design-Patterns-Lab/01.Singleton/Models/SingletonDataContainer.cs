using DesignPatternsLab.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.Singleton.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        private static SingletonDataContainer _instance = new SingletonDataContainer();


        private SingletonDataContainer()
        {
            Console.WriteLine($"Initializing singleton object");

            string[] elements = File.ReadAllLines("../../../Files/capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                this._capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => _instance;

        public int GetPopulaton(string name)
        {
            return this._capitals[name];
        }
    }
}
