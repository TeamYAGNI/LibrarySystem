// <copyright file = "InvalidCommandException.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of InvalidCommandException class.</summary>

using System;

namespace LibrarySystem.Framework.Exceptions
{
    /// <summary>
    /// Represent a <see cref="InvalidCommandException"/> class, inheritant of <see cref="ApplicationException"/> class.
    /// </summary>
    public class InvalidCommandException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        /// <param name="message">The message of the invalid command.</param>
        public InvalidCommandException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        /// <param name="message">The message of the invalid command.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public InvalidCommandException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
