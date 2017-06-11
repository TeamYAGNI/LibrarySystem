using System.Collections.Generic;
using LibrarySystem.Models.Logs;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Logs.Contracts
{
    public interface ILogTypesRepository : IRepository<LogType>
    {
        IEnumerable<LogType> GetLogTypeByName(string logTypeName);
    }
}