using System;
using System.Collections.Generic;
using System.Text;
using TestCustomInjectionFramework.IO;

namespace TestCustomInjectionFramework.Models
{
    class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
