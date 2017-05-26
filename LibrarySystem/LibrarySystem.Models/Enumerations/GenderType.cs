// <copyright file="GenderType.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of GenderType enumeration.</summary>

namespace LibrarySystem.Models.Enumerations
{
    /// <summary>
    /// Represent a <see cref="GenderType"/> enumeration.
    /// </summary>
    public enum GenderType
    {
        /// <summary>Indicate that the gender type is not specified.</summary>
        NotSpecified = 0,

        /// <summary>Indicate female gender type.</summary>
        Female = 1,

        /// <summary>Indicate male gender type.</summary>
        Male = 2
    }
}