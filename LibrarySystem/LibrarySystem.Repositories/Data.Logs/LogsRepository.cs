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
    public class LogsRepository : Repository<Log>, ILogsRepository
    {
        public LogsRepository(LibrarySystemLogsDbContext context) : base(context)
        {

        }

        private LibrarySystemLogsDbContext LogsDbContext
        {
            get
            {
                return this.Context as LibrarySystemLogsDbContext;
            }
        }

        public IEnumerable<Log> Get10LatestLogs()
        {
            return this.LogsDbContext.Logs.OrderByDescending(l => l.DateTime).Take(10).ToList();
        }

        public IEnumerable<Log> GetLogsByDate(DateTime date)
        {
            return this.LogsDbContext.Logs.Where(l => l.DateTime.Date == date.Date).ToList();
        }

        public IEnumerable<Log> GetLogsByLogTypeName(string logTypeName)
        {
            return this.LogsDbContext.Logs.Where(l => l.LogType.Name == logTypeName).ToList();
        }
    }
}
