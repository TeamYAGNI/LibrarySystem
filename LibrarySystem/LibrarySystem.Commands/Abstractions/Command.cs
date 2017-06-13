using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Exceptions;

namespace LibrarySystem.Commands.Abstractions
{
    public abstract class Command : ICommand
    {
        protected readonly uint ParameterCount;

        protected Command(IEnumerable<object> dependencies, uint parameterCount)
        {
            if (dependencies.Any(d => d == null))
            {
                throw new InvalidCommandException($"The command could not be instantiated due to dependency being null");
            }

            this.ParameterCount = parameterCount;
        }

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count != this.ParameterCount)
            {
                throw new InvalidCommandException("Invalid command parameters count!");
            }
        }
    }
}
