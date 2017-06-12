// <copyright file = "ILogsUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ILogsUnitOfWork implementators.</summary>

namespace LibrarySystem.Repositories.Contracts.Data.Logs.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="ILogsUnitOfWork"/> interface. Heir of <see cref="IUnitOfWork"/>
    /// </summary>
    public interface ILogsUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets or sets <see cref="ILogTypesRepository"/> implementator instance.
        /// </summary>
        ILogsRepository Logs { get; set; }

        /// <summary>
        /// Gets or sets <see cref="ILogTypesRepository"/> implementator instance.
        /// </summary>
        ILogTypesRepository LogTypes { get; set; }
    }
}