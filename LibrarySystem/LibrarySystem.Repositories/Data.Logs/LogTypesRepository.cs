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
        /// Gets the context as a <see cref="LibrarySystemLogsDbContext"/>.
        /// </summary>
        private LibrarySystemLogsDbContext LogsDbContext
        {
            get
            {
                return this.Context as LibrarySystemLogsDbContext;
            }
        }

        /// <summary>
        /// Provide instance of log type by a given name.
        /// </summary>
        /// <param name="logTypeName">Name of the log type.</param>
        /// <returns>Instance of the log type with the given name.</returns>
        public LogType GetLogTypeByName(string logTypeName)
        {
            return this.LogsDbContext.LogTypes.FirstOrDefault(lt => lt.Name == logTypeName);
        }
    }
}
