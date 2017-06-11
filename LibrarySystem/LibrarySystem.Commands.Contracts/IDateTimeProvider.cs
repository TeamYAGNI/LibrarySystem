// <copyright file = "IDateTimeProvider.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IDateTimeProvider implementators.</summary>

using System;

namespace LibrarySystem.Commands.Contracts
{
    /// <summary>
    /// Represent a <see cref="IDateTimeProvider"/> interface.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Represent the method witch provide the current DateTime.
        /// </summary>
        /// <returns>Current DateTime.</returns>
        DateTime Now();
    }
}
