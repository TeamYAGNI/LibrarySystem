// <copyright file="LogsRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LogsRepository class.</summary>

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data.Logs;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data.Logs;

namespace LibrarySystem.Repositories.Data.Logs
{
    /// <summary>
    /// Represent a <see cref="LogsRepository"/> class. Heir of <see cref="Repository{Log}"/>.
    /// Implementator of <see cref="ILogsRepository"/> interface.
    /// </summary>
    public class LogsRepository : Repository<Log>, ILogsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogsRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public LogsRepository(LibrarySystemLogsDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the context as a <see cref="LibrarySystemDbContext"/>.
        /// </summary>
        private LibrarySystemLogsDbContext LogsDbContext
        {
            get
            {
                return this.Context as LibrarySystemLogsDbContext;
            }
        }

        /// <summary>
        /// Provide collection of ten topmost recent logs.
        /// </summary>
        /// <returns>Collection of at most ten topmost recent logs.</returns>
        public IEnumerable<Log> Get10LatestLogs()
        {
            return this.LogsDbContext.Logs.OrderByDescending(l => l.DateTime).Take(10).ToList();
        }

        /// <summary>
        /// Provide collection of logs by a given date.
        /// </summary>
        /// <param name="date">Date of the logs.</param>
        /// <returns>Collection of the logs from the given date.</returns>
        public IEnumerable<Log> GetLogsByDate(DateTime date)
        {
            return this.LogsDbContext.Logs.Where(l => l.DateTime.Date == date.Date).ToList();
        }

        /// <summary>
        /// Provide collection of logs of a specific type by a given name of the log type.
        /// </summary>
        /// <param name="logTypeName">Name of the log type.</param>
        /// <returns>Collection of the logs of the type with the given name.</returns>
        public IEnumerable<Log> GetLogsByLogTypeName(string logTypeName)
        {
            return this.LogsDbContext.Logs.Where(l => l.LogType.Name == logTypeName).ToList();
        }
    }
}
