using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commnads
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                Console.WriteLine(commandInterpreter.Read(input));
            }
        }
    }
}
