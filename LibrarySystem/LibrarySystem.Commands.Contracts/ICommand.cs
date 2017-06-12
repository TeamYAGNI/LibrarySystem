// <copyright file = "ICommand.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ICommand implementators.</summary>

using System.Collections.Generic;

namespace LibrarySystem.Commands.Contracts
{
    /// <summary>
    /// Represent a <see cref="ICommand"/> interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Represent the method which execute the command with given parameters.
        /// </summary>
        /// <param name="parameters">Parameters needed for execution of the command.</param>
        /// <returns>Response as string.</returns>
        string Execute(IList<string> parameters);
    }
}
