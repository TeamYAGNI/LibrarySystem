using System;
using System.Collections.Generic;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Logs.Contracts
{
    public interface ILogsRepository : IRepository<Log>
    {
        IEnumerable<Log> Get10LatestLogs();

        IEnumerable<Log> GetLogsByDate(DateTime date);

        IEnumerable<Log> GetLogsByLogTypeName(string logTypeName);
    }
}