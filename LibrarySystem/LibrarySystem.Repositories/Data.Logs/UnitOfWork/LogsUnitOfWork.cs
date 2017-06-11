using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using LibrarySystem.Data.Logs;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Logs.Contracts;

namespace LibrarySystem.Repositories.Data.Logs.UnitOfWork
{
    public class LogsUnitOfWork : IUnitOfWork, ILogsUnitOfWork
    {
        private readonly LibrarySystemLogsDbContext logsContext;
        private ILogsRepository logs;
        private ILogTypesRepository logTypes;

        public LogsUnitOfWork(LibrarySystemLogsDbContext logsContext, ILogsRepository logs, ILogTypesRepository logTypes)
        {
            Guard.WhenArgument(logsContext, "logsContext").IsNull().Throw();
            this.logsContext = logsContext;

            this.Logs = logs;
            this.LogTypes = logTypes;
        }

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

        public void Dispose()
        {
            this.logsContext.Dispose();
        }

        public int Commit()
        {
            return this.logsContext.SaveChanges();
        }
    }
}
