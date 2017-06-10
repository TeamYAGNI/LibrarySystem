using System;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
