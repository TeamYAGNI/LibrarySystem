using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Logs;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Data.Logs.Contracts;

namespace LibrarySystem.Repositories.Data.Logs
{
    public class LogTypesRepository : Repository<LogType>, ILogTypesRepository
    {
        public LogTypesRepository(LibrarySystemLogsDbContext context) : base(context)
        {
        }

        private LibrarySystemLogsDbContext LogsDbContext
        {
            get
            {
                return this.Context as LibrarySystemLogsDbContext;
            }
        }

        public IEnumerable<LogType> GetLogTypeByName(string logTypeName)
        {
            return this.LogsDbContext.LogTypes.Where(lt => lt.Name == logTypeName).ToList();
        }
    }
}
