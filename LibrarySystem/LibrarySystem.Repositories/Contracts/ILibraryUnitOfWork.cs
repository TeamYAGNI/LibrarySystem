namespace LibrarySystem.Repositories.Contracts
{
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }
    }
}