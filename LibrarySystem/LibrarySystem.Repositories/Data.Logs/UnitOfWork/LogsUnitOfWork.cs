using Bytes2you.Validation;

using LibrarySystem.Data.Logs;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Logs;
using LibrarySystem.Repositories.Contracts.Data.Logs.UnitOfWork;

namespace LibrarySystem.Repositories.Data.Logs.UnitOfWork
{
    public class LogsUnitOfWork : IUnitOfWork, ILogsUnitOfWork
    {
        private readonly LibrarySystemLogsDbContext logsContext;

        public LogsUnitOfWork(LibrarySystemLogsDbContext logsContext, ILogsRepository logs, ILogTypesRepository logTypes)
        {
            Guard.WhenArgument(logsContext, "logsContext").IsNull().Throw();
            this.logsContext = logsContext;

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
