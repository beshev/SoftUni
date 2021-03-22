using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == $"{tokens[0]}Command")
                .FirstOrDefault();

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            return commandInstance.Execute(tokens.Skip(1).ToArray());
        }
    }
}
