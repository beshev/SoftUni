using System;
using System.Collections.Generic;
using System.Text;
using TestCustomInjectionFramework.IO;

namespace TestCustomInjectionFramework.Models
{
    class ConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.Write(s);
        }
    }
}
