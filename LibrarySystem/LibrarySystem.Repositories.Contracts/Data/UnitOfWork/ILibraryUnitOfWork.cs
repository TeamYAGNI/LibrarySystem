// <copyright file = "ILibraryUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ILibraryUnitOfWork implementators.</summary>

namespace LibrarySystem.Repositories.Contracts.Data.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="ILibraryUnitOfWork"/> interface. Heir of <see cref="IUnitOfWork"/>
    /// </summary>
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets <see cref="IBookRepository"/> implementator instance.
        /// </summary>
        IBookRepository Books { get; }

        /// <summary>
        /// Gets <see cref="IJournalRepository"/> implementator instance.
        /// </summary>
        IJournalRepository Journals { get; }

        /// <summary>
        /// Gets <see cref="IGenreRepository"/> implementator instance.
        /// </summary>
        IGenreRepository Genres { get; }

        /// <summary>
        /// Gets <see cref="IPublisherRepository"/> implementator instance.
        /// </summary>
        IPublisherRepository Publishers { get; }

        /// <summary>
        /// Gets <see cref="IAuthorRepository"/> implementator instance.
        /// </summary>
        IAuthorRepository Authors { get; }

        /// <summary>
        /// Gets <see cref="ISubjectRepository"/> implementator instance.
        /// </summary>
        ISubjectRepository Subjects { get; }

        /// <summary>
        /// Gets <see cref="IClientRepository"/> implementator instance.
        /// </summary>
        IClientRepository Clients { get; }

        /// <summary>
        /// Gets <see cref="IEmployeeRepository"/> implementator instance.
        /// </summary>
        IEmployeeRepository Employees { get; }

        /// <summary>
        /// Gets <see cref="IAddressRepository"/> implementator instance.
        /// </summary>
        IAddressRepository Addresses { get; }

        /// <summary>
        /// Gets <see cref="ICityRepository"/> implementator instance.
        /// </summary>
        ICityRepository Cities { get; }

        /// <summary>
        /// Gets <see cref="ILendingRepository"/> implementator instance.
        /// </summary>
        ILendingRepository Lendings { get; }
    }
}