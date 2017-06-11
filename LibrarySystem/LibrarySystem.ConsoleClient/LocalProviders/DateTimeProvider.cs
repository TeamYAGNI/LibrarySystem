// <copyright file = "DateTimeProvider.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of DateTimeProvider class.</summary>

using System;

using LibrarySystem.Commands.Contracts;

namespace LibrarySystem.ConsoleClient.LocalProviders
{
    /// <summary>
    /// Represent a <see cref="DateTimeProvider"/> class, implementator of <see cref="IDateTimeProvider"/> interface.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Represent the method witch provide the current DateTime.
        /// </summary>
        /// <returns>Current DateTime.</returns>
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
