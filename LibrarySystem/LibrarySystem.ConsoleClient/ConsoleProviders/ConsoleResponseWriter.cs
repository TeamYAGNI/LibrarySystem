// <copyright file = "ConsoleResponseWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ConsoleResponseWriter class.</summary>

using System;

using LibrarySystem.Framework.Contracts;

namespace LibrarySystem.ConsoleClient.ConsoleProviders
{
    /// <summary>
    /// Represent a <see cref="ConsoleResponseWriter"/> class, implementator of <see cref="IResponseWriter"/> interface.
    /// </summary>
    public class ConsoleResponseWriter : IResponseWriter
    {
        /// <summary>
        /// Represent the method witch writes response message.
        /// </summary>
        /// <param name="message">Message to be written.</param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Represent the method witch writes response message in a separate line.
        /// </summary>
        /// <param name="message">Message to be written in a separate line.</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
