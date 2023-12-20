using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
