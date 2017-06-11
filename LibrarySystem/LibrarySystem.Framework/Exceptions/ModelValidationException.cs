// <copyright file = "ModelValidationException.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ModelValidationException class.</summary>

using System;

namespace LibrarySystem.Framework.Exceptions
{
    /// <summary>
    /// Represent a <see cref="ModelValidationException"/> class, inheritant of <see cref="ApplicationException"/> class.
    /// </summary>
    public class ModelValidationException : ApplicationException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public ModelValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public ModelValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}