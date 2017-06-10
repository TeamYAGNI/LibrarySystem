// <copyright file="UserType.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of UserType enumeration.</summary>

namespace LibrarySystem.Models.Enumerations
{
    /// <summary>
    /// Represent a <see cref="UserType"/> enumeration.
    /// </summary>
    public enum UserType
    {
        /// <summary>Indicate regular user.</summary>
        Regular = 0,

        /// <summary>Indicate administrator.</summary>
        Admin = 1,

        /// <summary>Indicate master user.</summary>
        Master = 2
    }
}
