// <copyright file = "IEngine.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IEngine implementators.</summary>

namespace LibrarySystem.Framework.Contracts
{
    /// <summary>
    /// Represent a <see cref="IEngine"/> interface.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Represent the method witch holds the main logic of the <see cref="IEngine"/> implementator.
        /// </summary>
        void Start();
    }
}