using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Repositories.Data.UnitOfWork
{
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }

        IJournalRepository Journals { get; }

        IGenreRepository Genres { get; }

        IPublisherRepository Publishers { get; }

        IAuthorRepository Authors { get; }

        ISubjectRepository Subjects { get; }

        IClientRepository Clients { get; }

        IEmployeeRepository Employees { get; }

        IAddressRepository Addresses { get; }

        ICityRepository Cities { get; }

        ILendingRepository Lendings { get; }

    }
}