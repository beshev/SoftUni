using System;
using System.Collections.Generic;
using System.Text;

namespace TestCase
{
    class SetElements
    {
        public List<string> Keys { get; set; }
    }
    public class SetHashFuncion
    {
        SetElements[] array;
        public SetHashFuncion(int capaciy = 8)
        {
            array = new SetElements[capaciy];
        }

        public void Add(string key)
        {
            if (array[HashFunction(key)] != null)
            {
                array[HashFunction(key)].Keys.Add(key);
            }
            else
            {
                array[HashFunction(key)] = new SetElements() { Keys = new List<string>() { key } };
            }
        }

        private int HashFunction(string key)
        {
            int result = (key[0] << 5) | key[key.Length - 1] >> 4;
            return result % array.Length;
        }

        public bool Contains(string key)
        {
            if (array[HashFunction(key)] != null)
            {
                for (int i = 0; i < array[HashFunction(key)].Keys.Count; i++)
                {
                    if (array[HashFunction(key)].Keys[i] == key)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
