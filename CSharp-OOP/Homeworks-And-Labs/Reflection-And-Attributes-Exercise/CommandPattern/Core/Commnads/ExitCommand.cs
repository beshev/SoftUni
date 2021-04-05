using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commnads
{
    class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
