using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Logs.Contracts;

namespace LibrarySystem.Repositories.Data.Logs.UnitOfWork
{
    public interface ILogsUnitOfWork : IUnitOfWork
    {
        ILogsRepository Logs { get; set; }

        ILogTypesRepository LogTypes { get; set; }
    }
}