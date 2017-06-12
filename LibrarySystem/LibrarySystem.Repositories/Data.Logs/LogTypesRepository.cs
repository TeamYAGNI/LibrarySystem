// <copyright file="LogTypesRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LogTypesRepository class.</summary>

using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data.Logs;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data.Logs;

namespace LibrarySystem.Repositories.Data.Logs
{
    /// <summary>
    /// Represent a <see cref="LogTypesRepository"/> class. Heir of <see cref="Repository{LogType}"/>.
    /// Implementator of <see cref="ILogTypesRepository"/> interface.
    /// </summary>
    public class LogTypesRepository : Repository<LogType>, ILogTypesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogTypesRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public LogTypesRepository(LibrarySystemLogsDbContext context) : base(context)
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
        /// Provide collection of logs by a given name.
        /// </summary>
        /// <param name="logTypeName">Name of the log type.</param>
        /// <returns>collection of the logs with the given name.</returns>
        public IEnumerable<LogType> GetLogTypeByName(string logTypeName)
        {
            return this.LogsDbContext.LogTypes.Where(lt => lt.Name == logTypeName).ToList();
        }
    }
}
