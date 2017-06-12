// <copyright file = "ILogsRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ILogsRepository implementators.</summary>

using System;
using System.Collections.Generic;

using LibrarySystem.Models.Logs;

namespace LibrarySystem.Repositories.Contracts.Data.Logs
{
    /// <summary>
    /// Represent a <see cref="ILogsRepository"/> interface. Heir of <see cref="IRepository{Log}"/>
    /// </summary>
    public interface ILogsRepository : IRepository<Log>
    {
        /// <summary>
        /// Provide collection of ten topmost recent logs.
        /// </summary>
        /// <returns>Collection of at most ten topmost recent logs.</returns>
        IEnumerable<Log> Get10LatestLogs();

        /// <summary>
        /// Provide collection of logs by a given date.
        /// </summary>
        /// <param name="date">Date of the logs.</param>
        /// <returns>Collection of the logs from the given date.</returns>
        IEnumerable<Log> GetLogsByDate(DateTime date);

        /// <summary>
        /// Provide collection of logs of a specific type by a given name of the log type.
        /// </summary>
        /// <param name="logTypeName">Name of the log type.</param>
        /// <returns>Collection of the logs of the type with the given name.</returns>
        IEnumerable<Log> GetLogsByLogTypeName(string logTypeName);
    }
}