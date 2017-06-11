// <copyright file = "ConsoleCommandReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ConsoleCommandReader class.</summary>

using System;

using LibrarySystem.Framework.Contracts;

namespace LibrarySystem.ConsoleClient.ConsoleProviders
{
    /// <summary>
    /// Represent a <see cref="ConsoleCommandReader"/> class, implementator of <see cref="ICommandReader"/> interface.
    /// </summary>
    public class ConsoleCommandReader : ICommandReader
    {
        /// <summary>
        /// Represent the method which provide a command.
        /// </summary>
        /// <returns>Command as string.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
