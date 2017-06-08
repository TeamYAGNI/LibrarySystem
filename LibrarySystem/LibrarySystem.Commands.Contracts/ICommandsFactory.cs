// <copyright file = "ICommandsFactory.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ICommandsFactory implementators.</summary>

namespace LibrarySystem.Commands.Contracts
{
    /// <summary>
    /// Represent a <see cref="ICommandsFactory"/> interface.
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Represent the method witch provide a instance of <see cref="ICommand"/> implementator by a given command name.
        /// </summary>
        /// <param name="commandName">Name of the command to be provided.</param>
        /// <returns>Instance of <see cref="ICommand"/> implementator</returns>
        ICommand GetCommand(string commandName);
    }
}
