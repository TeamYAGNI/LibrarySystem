// <copyright file = "ICommandReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ICommandReader implementators.</summary>

namespace LibrarySystem.Framework.Contracts
{
    /// <summary>
    /// Represent a <see cref="ICommandReader"/> interface.
    /// </summary>
    public interface ICommandReader
    {
        /// <summary>
        /// Represent the method which provide a command.
        /// </summary>
        /// <returns>Command as string.</returns>
        string ReadLine();
    }
}