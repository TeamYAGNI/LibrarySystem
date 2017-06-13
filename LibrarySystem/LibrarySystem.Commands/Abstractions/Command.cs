using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Exceptions;

namespace LibrarySystem.Commands.Abstractions
{
    public abstract class Command : ICommand
    {
        protected readonly uint ParameterCount;
        private const string NullDependencyMessage =
            "The command could not be instantiated due to dependency being null";
        private const string InvalidParametersCountMessage = "Invalid command parameters count!";
        private const string InvalidParametersListMessage = "Parameter collection not instantiated";

        protected Command(IEnumerable<object> dependencies, uint parameterCount)
        {
            if (dependencies.Any(d => d == null))
            {
                throw new InvalidCommandException(NullDependencyMessage);
            }

            this.ParameterCount = parameterCount;
        }

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count != this.ParameterCount)
            {
                throw new InvalidCommandException(InvalidParametersCountMessage);
            }

            if (parameters == null)
            {
                throw new InvalidCommandException(InvalidParametersListMessage);
            }
        }
    }
}
