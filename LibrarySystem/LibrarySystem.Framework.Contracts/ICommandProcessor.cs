// <copyright file = "ICommandProcessor.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ICommandProcessor implementators.</summary>

namespace LibrarySystem.Framework.Contracts
{
    /// <summary>
    /// Represent a <see cref="ICommandProcessor"/> interface.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Represent the method which process a command.
        /// </summary>
        /// <param name="fullCommand">Full command to be processed.</param>
        /// <returns>Response as string.</returns>
        string ProcessCommand(string fullCommand);
    }
}