// <copyright file = "IValidator.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IValidator implementators.</summary>

using System;

namespace LibrarySystem.Framework.Contracts
{
    /// <summary>
    /// Represent a <see cref="IValidator"/> interface.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Represent the method which validate a generic object.
        /// </summary>
        /// <typeparam name="T">The type of object to be validated.</typeparam>
        /// <param name="obj">Generic object to be validated by the <see cref="IValidator"/> implementator.</param>
        /// <param name="onValidationFail">Action to be executed in case of validation failure.</param>
        void Validate<T>(T obj, Action<string> onValidationFail = null) where T : class;
    }
}
