// <copyright file="LogsUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LogsUnitOfWork class.</summary>

using Bytes2you.Validation;

using LibrarySystem.Data.Logs;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Logs;
using LibrarySystem.Repositories.Contracts.Data.Logs.UnitOfWork;

namespace LibrarySystem.Repositories.Data.Logs.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="LogsUnitOfWork"/> class.
    /// Implementator of <see cref="IUnitOfWork"/> and <see cref="ILogsUnitOfWork"/> interfaces.
    /// </summary>
    public class LogsUnitOfWork : IUnitOfWork, ILogsUnitOfWork
    {
        /// <summary>Context that provide connection to the database.</summary>
        private readonly LibrarySystemLogsDbContext logsContext;

        /// <summary>Logs repository.</summary>
        private ILogsRepository logs;

        /// <summary>LogTypes repository.</summary>
        private ILogTypesRepository logTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsUnitOfWork"/> class.
        /// </summary>
        /// <param name="logsContext">Context that provide connection to the database.</param>
        /// <param name="logs">Logs repository.</param>
        /// <param name="logTypes">LogTypes repository.</param>
        public LogsUnitOfWork(LibrarySystemLogsDbContext logsContext, ILogsRepository logs, ILogTypesRepository logTypes)
        {
            Guard.WhenArgument(logsContext, "logsContext").IsNull().Throw();
            this.logsContext = logsContext;

            this.Logs = logs;
            this.LogTypes = logTypes;
        }

        /// <summary>
        /// Gets or sets <see cref="ILogsRepository"/> instance.
        /// </summary>
        public ILogsRepository Logs
        {
            get
            {
                return this.logs;
            }

            set
            {
                Guard.WhenArgument(value, "Logs").IsNull().Throw();

                this.logs = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="ILogTypesRepository"/> instance.
        /// </summary>
        public ILogTypesRepository LogTypes
        {
            get
            {
                return this.logTypes;
            }

            set
            {
                Guard.WhenArgument(value, "LogTypes").IsNull().Throw();

                this.logTypes = value;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.logsContext.Dispose();
        }

        /// <summary>
        /// Make a transaction to save the changes of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        public int Commit()
        {
            return this.logsContext.SaveChanges();
        }
    }
}
