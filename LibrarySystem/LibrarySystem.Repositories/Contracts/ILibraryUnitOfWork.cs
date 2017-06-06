using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }
    }
}