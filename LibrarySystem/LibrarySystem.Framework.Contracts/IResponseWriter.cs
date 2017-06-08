// <copyright file = "IResponseWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IResponseWriter implementators.</summary>

namespace LibrarySystem.Framework.Contracts
{
    /// <summary>
    /// Represent a <see cref="IResponseWriter"/> interface.
    /// </summary>
    public interface IResponseWriter
    {
        /// <summary>
        /// Represent the method witch writes response message.
        /// </summary>
        /// <param name="message">Message to be written.</param>
        void Write(string message);

        /// <summary>
        /// Represent the method witch writes response message in a separate line.
        /// </summary>
        /// <param name="message">Message to be written in a separate line.</param>
        void WriteLine(string message);
    }
}