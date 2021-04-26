using CustomDependencyInjectionFramework.Attributes;
using CustomDependencyInjectionFramework.Injectors;
using System;
using System.Collections.Generic;
using System.Text;
using TestCustomInjectionFramework.IO;
using TestCustomInjectionFramework.Models;
using TestCustomInjectionFramework.Module;

namespace TestCustomInjectionFramework
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;

        [Inject]
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }



        public void Run()
        {
            while (true)
            {
                writer.Write(reader.Read());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
