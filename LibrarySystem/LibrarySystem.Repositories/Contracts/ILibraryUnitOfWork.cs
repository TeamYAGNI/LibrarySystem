namespace LibrarySystem.Repositories.Contracts
{
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }

        IJournalRepository Journals { get; }

        IGenreRepository Genres { get; }
    }
}