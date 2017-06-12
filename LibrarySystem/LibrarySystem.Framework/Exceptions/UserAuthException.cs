// <copyright file = "UserAuthException.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of UserAuthException class.</summary>

using System;

namespace LibrarySystem.Framework.Exceptions
{
    /// <summary>
    /// Represent a <see cref="UserAuthException"/> class, inheritant of <see cref="ApplicationException"/> class.
    /// </summary>
    public class UserAuthException : ApplicationException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuthException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public UserAuthException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuthException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public UserAuthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}